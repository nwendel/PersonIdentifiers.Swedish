using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using PersonIdentifiers.Swedish.Internal;

namespace PersonIdentifiers.Swedish.Local.RegionSkane;

public sealed class RegionSkaneLocalReserveNumberIdentifier : LocalReserveNumberIdentifier
{
    private static readonly Regex _pattern = new(@"^(\d{6}|\d{8})[D|E|F][A-Z][0|1][A-Z]$");

    private RegionSkaneLocalReserveNumberIdentifier(string value, PersonIdentifierParts parts)
        : base(value, parts)
    {
    }

    public override LocalReserveNumberPrincipal Principal => LocalReserveNumberPrincipal.RegionSkane;

    public override string Oid => PersonIdentifierOids.LocalReserveNumberRegionSkane;

    public static new RegionSkaneLocalReserveNumberIdentifier Parse(string value) =>
        TryParse(value, out var identifier)
            ? identifier
            : throw new RegionSkaneLocalReserveNumberIdentifierFormatException();

    public static bool TryParse(string value, [NotNullWhen(true)] out RegionSkaneLocalReserveNumberIdentifier? identifier)
    {
        GuardAgainst.Null(value);

        identifier = default;
        if (!_pattern.IsMatch(value))
        {
            return false;
        }

        var parts = new RegionSkaneLocalReserveNumberIdentifierParts(value);
        var year = parts.Year;
        if (parts.Kind == RegionSkaneLocalReserveNumberKind.Short)
        {
            // TODO: Add 2000 or 1900 based on some rule
            year += 1900;
        }

        if (LocalDateHelper.IsInvalidDate(year, parts.Month, parts.Day))
        {
            return false;
        }

        // TODO: More here
        identifier = new(value, parts)
        {
            DateOfBirth = new(year, parts.Month, parts.Day),
            Gender = parts.Gender == '0'
                ? PersonIdentifierGender.Female
                : PersonIdentifierGender.Male,
        };
        return true;
    }
}
