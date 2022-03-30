using System.Diagnostics.CodeAnalysis;
using PersonIdentifiers.Swedish.Internal;

namespace PersonIdentifiers.Swedish.Local.RegionSkane;

public sealed class RegionSkaneReserveNumberIdentifier : LocalReserveNumberIdentifier
{
    private RegionSkaneReserveNumberIdentifier(string value, PersonIdentifierParts parts)
        : base(value, parts)
    {
    }

    public override LocalReserveNumberPrincipal Principal => LocalReserveNumberPrincipal.RegionSkane;

    public override string Oid => PersonIdentifierOids.LocalReserveNumberRegionSkane;

    public static new RegionSkaneReserveNumberIdentifier Parse(string value) =>
        TryParse(value, out var identifier)
            ? identifier
            : throw new RegionSkaneReserveNumberIdentifierFormatException();

    public static bool TryParse(string value, [NotNullWhen(true)] out RegionSkaneReserveNumberIdentifier? identifier)
    {
        GuardAgainst.Null(value);

        // TODO: More here
        identifier = new(value, new RegionSkaneReserveNumberIdentifierParts());
        return true;
    }
}
