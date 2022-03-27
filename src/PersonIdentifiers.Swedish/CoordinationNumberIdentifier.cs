using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text.RegularExpressions;
using NodaTime;
using PersonIdentifiers.Swedish.Internal;

namespace PersonIdentifiers.Swedish;

public sealed class CoordinationNumberIdentifier : PersonIdentifier
{
    private static readonly Regex _pattern = new(@"^(\d{2})(\d{2})(\d{2})(([6-9]){1})(\d{1})(([0-9]){4})$");

    private CoordinationNumberIdentifier(string value, PersonIdentifierParts parts)
        : base(value, parts)
    {
    }

    public override PersonIdentifierKind Kind => PersonIdentifierKind.CoordinationNumber;

    public override string Oid => PersonIdentifierOids.CoordinationNumber;

    public new LocalDate DateOfBirth
    {
        get => base.DateOfBirth ?? throw new UnreachableCodeException();
        private set => base.DateOfBirth = value;
    }

    public new PersonIdentifierGender Gender
    {
        get => base.Gender ?? throw new UnreachableCodeException();
        private set => base.Gender = value;
    }

    public static bool TryParse(string value, [NotNullWhen(true)] out CoordinationNumberIdentifier? identifier)
    {
        GuardAgainst.Null(value);

        identifier = default;
        if (!_pattern.IsMatch(value) || !Luhn.IsValid(value[2..]))
        {
            return false;
        }

        var parts = new PersonIdentifierParts(value);
        var year = int.Parse(parts.Year, CultureInfo.CurrentCulture);
        var month = int.Parse(parts.Month, CultureInfo.CurrentCulture);
        var day = int.Parse(parts.Day, CultureInfo.CurrentCulture) - 60;
        if (LocalDateHelper.IsInvalidDate(year, month, day))
        {
            return false;
        }

        identifier = new CoordinationNumberIdentifier(value, parts)
        {
            DateOfBirth = new LocalDate(year, month, day),
            Gender = GetGender(),
        };

        return true;

        PersonIdentifierGender GetGender()
        {
            var genderDigit = parts.Gender[0] - '0';
            return genderDigit.IsOdd()
                ? PersonIdentifierGender.Male
                : PersonIdentifierGender.Female;
        }
    }
}
