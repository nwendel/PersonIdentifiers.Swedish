using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using NodaTime;
using PersonIdentifiers.Swedish.Internal;

namespace PersonIdentifiers.Swedish;

// https://confluence.cgiostersund.se/display/PU/Nationellt+Reservid
public sealed class NationalReserveNumberIdentifier :
    PersonIdentifier,
    IPersonIdentifierPartsAware<StandardPersonIdentifierParts>
{
    private static readonly Regex _pattern = new(@"^([0-9]{8})((?![IOQVW])[A-Z]{2}[0-9]{2}|(?![IOQVW])[A-Z]{3}[0-9]{1})$");

    private NationalReserveNumberIdentifier(
        string value,
        StandardPersonIdentifierParts parts)
        : base(value, parts)
    {
    }

    public override PersonIdentifierKind Kind => PersonIdentifierKind.NationalReserveNumber;

    public override string Oid => PersonIdentifierOids.NationalReserveNumber;

    public override StandardPersonIdentifierParts Parts => (StandardPersonIdentifierParts)base.Parts;

    public static new NationalReserveNumberIdentifier Parse(string value) =>
        TryParse(value, out var identifier)
            ? identifier
            : throw new NationalReserveNumberIdentifierFormatException();

    public static bool TryParse(string value, [NotNullWhen(true)] out NationalReserveNumberIdentifier? identifier)
    {
        GuardAgainst.Null(value);

        identifier = default;
        if (!_pattern.IsMatch(value) || !Luhn.IsValid(value))
        {
            return false;
        }

        // TODO: Also check blacklisted texts in value: https://www.transportstyrelsen.se/sv/vagtrafik/Fordon/Om-registreringsskylt/Byte-av-registreringsnummer/Sparrade-bokstavskombinationer/
        var parts = new StandardPersonIdentifierParts(value);
        var century = parts.Century;
        if (!IsValidCentury())
        {
            return false;
        }

        if (!TryGetDateOfBirth(out var dateOfBirth))
        {
            return false;
        }

        identifier = new NationalReserveNumberIdentifier(value, parts)
        {
            DateOfBirth = dateOfBirth,
            Gender = GetGender(),
        };

        return true;

        bool IsValidCentury() =>
            century == 0 ||
            (century >= 22 && century <= 78 && (century - 22) % 3 == 0);

        bool TryGetDateOfBirth(out LocalDate? dateOfBirth)
        {
            dateOfBirth = default;

            var year = parts.Year;
            var month = parts.Month;
            var day = parts.Day;

            if (century == 0)
            {
                if (month < 20 || day < 40 || day > 59)
                {
                    return false;
                }

                return true;
            }

            // Calculate actual year for age
            while (year >= 2200)
            {
                year -= 300;
            }

            if (LocalDateHelper.IsInvalidDate(year, month, day))
            {
                return false;
            }

            dateOfBirth = new LocalDate(year, month, day);
            return true;
        }

        PersonIdentifierGender? GetGender()
        {
            var gender = parts.Gender;
            if (char.IsLetter(gender))
            {
                return null;
            }

            var genderDigit = gender - '0';
            return genderDigit.IsOdd()
                ? PersonIdentifierGender.Male
                : PersonIdentifierGender.Female;
        }
    }
}
