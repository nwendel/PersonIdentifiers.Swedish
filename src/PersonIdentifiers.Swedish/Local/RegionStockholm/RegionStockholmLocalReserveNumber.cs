using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using PersonIdentifiers.Swedish.Internal;
using PersonIdentifiers.Swedish.Parts;

namespace PersonIdentifiers.Swedish.Local.RegionStockholm;

public sealed class RegionStockholmLocalReserveNumber : LocalReserveNumber
{
    private static readonly Regex _pattern = new(@"^99(\d{10})$");

    private RegionStockholmLocalReserveNumber(string value, PersonIdentifierParts parts)
        : base(value, parts)
    {
    }

    public override LocalReserveNumberPrincipal Principal => LocalReserveNumberPrincipal.RegionStockholm;

    public override string Oid => PersonIdentifierOids.LocalReserveNumberRegionStockholm;

    public static new RegionStockholmLocalReserveNumber Parse(string value) =>
        TryParse(value, out var identifier)
            ? identifier
            : throw new PersonIdentifierFormatException(typeof(RegionStockholmLocalReserveNumber));

    public static bool TryParse(string value, [NotNullWhen(true)] out RegionStockholmLocalReserveNumber? identifier)
    {
        GuardAgainst.Null(value);

        identifier = default;
        if (!_pattern.IsMatch(value) || !Luhn.IsValid(value[2..]))
        {
            return false;
        }

        var parts = new RegionStockholmLocalReserveNumberParts(value);

        if (parts.Year < 1980 || parts.Year > 2299)
        {
            return false;
        }

        identifier = new RegionStockholmLocalReserveNumber(value, parts);

        return true;
    }
}
