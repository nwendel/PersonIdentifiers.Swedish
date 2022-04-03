using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using PersonIdentifiers.Swedish.Internal;

namespace PersonIdentifiers.Swedish;

// https://confluence.cgiostersund.se/display/PU/Nationellt+Reservid
[SuppressMessage("Design", "CA1067:Override Object.Equals(object) when implementing IEquatable<T>", Justification = "Not needed, overriden correctly in PersonIdentifier")]
public sealed class NationalReserveNumber :
    PersonIdentifier,
    IPersonIdentifierPartsAware<StandardPersonIdentifierParts>,
    IEquatable<NationalReserveNumber>
{
    private static readonly Regex _pattern = new(@"^([0-9]{8})((?![IOQVW])[A-Z]{2}[0-9]{2}|(?![IOQVW])[A-Z]{3}[0-9]{1})$");

    private NationalReserveNumber(
        string value,
        StandardPersonIdentifierParts parts)
        : base(value, parts)
    {
    }

    public override PersonIdentifierKind Kind => PersonIdentifierKind.NationalReserveNumber;

    public override string Oid => PersonIdentifierOids.NationalReserveNumber;

    public override StandardPersonIdentifierParts Parts => (StandardPersonIdentifierParts)base.Parts;

    public static new NationalReserveNumber Parse(string value) =>
        TryParse(value, out var identifier)
            ? identifier
            : throw new NationalReserveNumberFormatException();

    public static bool TryParse(string value, [NotNullWhen(true)] out NationalReserveNumber? identifier)
    {
        GuardAgainst.Null(value);

        identifier = default;
        if (!_pattern.IsMatch(value) || !Luhn.IsValid(value))
        {
            return false;
        }

        var parts = new NationalReserveNumberParts(value);
        if (Blacklists.Transportstyrelsen.Contains(parts.SequenceAndGender))
        {
            return false;
        }

        var century = parts.Century;
        if (!IsValidCentury())
        {
            return false;
        }

        if (!TryGetDateOfBirth(out var dateOfBirth))
        {
            return false;
        }

        identifier = new NationalReserveNumber(value, parts)
        {
            DateOfBirth = dateOfBirth,
            Gender = GetGender(),
        };

        return true;

        bool IsValidCentury() =>
            century == 0 ||
            (century >= 22 && century <= 78 && (century - 22) % 3 == 0);

        bool TryGetDateOfBirth(out DateOnly? dateOfBirth)
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

            if (!DateOnlyHelper.IsValidDate(year, month, day, out dateOfBirth))
            {
                return false;
            }

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

    public bool Equals(NationalReserveNumber? other) => Value == other?.Value;
}
