using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using PersonIdentifiers.Swedish.Internal;
using PersonIdentifiers.Swedish.Parts;

namespace PersonIdentifiers.Swedish.LocalReserveNumbers.RegionSkane;

public sealed class RegionSkaneLocalReserveNumber : LocalReserveNumber
{
    private static readonly Regex _pattern = new(@"^(\d{8})[D|E|F][A-Z][0|1][A-Z]$");

    private RegionSkaneLocalReserveNumber(string value, PersonIdentifierParts parts)
        : base(value, parts)
    {
    }

    public override LocalReserveNumberPrincipal Principal => LocalReserveNumberPrincipal.RegionSkane;

    public override string Oid => PersonIdentifierOids.LocalReserveNumberRegionSkane;

    public static new RegionSkaneLocalReserveNumber Parse(string value) =>
        TryParse(value, out var identifier)
            ? identifier
            : throw new PersonIdentifierFormatException(typeof(RegionSkaneLocalReserveNumber));

    public static bool TryParse(string value, [NotNullWhen(true)] out RegionSkaneLocalReserveNumber? identifier)
    {
        GuardAgainst.Null(value);

        identifier = default;
        if (!_pattern.IsMatch(value))
        {
            return false;
        }

        var parts = new RegionSkaneLocalReserveNumberParts(value);
        if (!DateOnlyHelper.IsValidDate(parts.Year, parts.Month, parts.Day, out var dateOfBirth))
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
    }
}
