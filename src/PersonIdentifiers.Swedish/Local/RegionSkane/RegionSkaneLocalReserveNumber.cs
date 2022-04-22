using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using PersonIdentifiers.Swedish.Internal;

namespace PersonIdentifiers.Swedish.Local.RegionSkane;

public sealed class RegionSkaneLocalReserveNumber : LocalReserveNumber
{
    private static readonly Regex _pattern = new(@"^(\d{6}|\d{8})[D|E|F][A-Z][0|1][A-Z]$");

    private RegionSkaneLocalReserveNumber(string value, PersonIdentifierParts parts)
        : base(value, parts)
    {
    }

    public override LocalReserveNumberPrincipal Principal => LocalReserveNumberPrincipal.RegionSkane;

    public override string Oid => PersonIdentifierOids.LocalReserveNumberRegionSkane;

    public static new RegionSkaneLocalReserveNumber Parse(string value) =>
        TryParse(value, out var identifier)
            ? identifier
            : throw new RegionSkaneLocalReserveNumberFormatException();

    public static bool TryParse(string value, [NotNullWhen(true)] out RegionSkaneLocalReserveNumber? identifier) =>
        TryParse(value, RegionSkaneLocalReserveNumberOptions.Default, out identifier);

    public static bool TryParse(string value, RegionSkaneLocalReserveNumberOptions options, [NotNullWhen(true)] out RegionSkaneLocalReserveNumber? identifier)
    {
        GuardAgainst.Null(value);

        identifier = default;
        if (!_pattern.IsMatch(value))
        {
            return false;
        }

        var parts = new RegionSkaneLocalReserveNumberParts(value);
        if (!TryGetDateOfBirth(out var dateOfBirth))
        {
            return false;
        }

        identifier = new(value, parts)
        {
            DateOfBirth = dateOfBirth,
            Gender = parts.Gender switch
            {
                '0' => PersonIdentifierGender.Female,
                '1' => PersonIdentifierGender.Male,
                _ => throw new UnreachableCodeException($"Gender part is '{parts.Gender}'"),
            },
        };
        return true;

        bool TryGetDateOfBirth([NotNullWhen(true)] out DateOnly? dateOfBirth) => parts.Kind switch
        {
            RegionSkaneLocalReserveNumberKind.Short => TryGetDateOfBirthShort(out dateOfBirth),
            RegionSkaneLocalReserveNumberKind.Long => DateOnlyHelper.IsValidDate(parts.Year, parts.Month, parts.Day, out dateOfBirth),
        };

        bool TryGetDateOfBirthShort(out DateOnly? dateOfBirth)
        {
            // TODO: If guess the century logic is needed elsewhere then refactor this out from here
            var year = parts.Year + 2000;
            if (DateOnlyHelper.IsValidDate(year, parts.Month, parts.Day, out dateOfBirth) &&
                dateOfBirth <= DateOnlyHelper.Today())
            {
                return true;
            }

            year -= 100;
            if (!DateOnlyHelper.IsValidDate(year, parts.Month, parts.Day, out dateOfBirth))
            {
                return false;
            }

            dateOfBirth = new(year, parts.Month, parts.Day);
            return true;
        }
    }
}
