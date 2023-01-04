using System.Globalization;
using PersonIdentifiers.Swedish.Internal;
using PersonIdentifiers.Swedish.Parts;

namespace PersonIdentifiers.Swedish.LocalReserveNumbers.RegionStockholm;

public class RegionStockholmLocalReserveNumberParts : PersonIdentifierParts
{
    public RegionStockholmLocalReserveNumberParts(string value)
    {
        GuardAgainst.Null(value);

        Year = int.Parse(value[2..6], CultureInfo.CurrentCulture);
        Sequence = value[6..12];
        CheckDigit = value[2];
    }

    public int Year { get; }

    public string Sequence { get; }

    public char CheckDigit { get; }

    public override IEnumerator<(string Name, object Value)> GetEnumerator()
    {
        yield return (Name: nameof(Year), Value: Year);
        yield return (Name: nameof(Sequence), Value: Sequence);
        yield return (Name: nameof(CheckDigit), Value: CheckDigit);
    }
}
