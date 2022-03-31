using System.Globalization;
using PersonIdentifiers.Swedish.Internal;

namespace PersonIdentifiers.Swedish.Local.RegionSkane;

public class RegionSkaneLocalReserveNumberParts : PersonIdentifierParts
{
    private const int ShortLength = 10;
    private const int LongLength = 12;

    public RegionSkaneLocalReserveNumberParts(string value)
    {
        GuardAgainst.Null(value);

        switch (value.Length)
        {
            case ShortLength:
                Kind = RegionSkaneLocalReserveNumberKind.Short;
                Year = int.Parse(value[0..2], CultureInfo.CurrentCulture);
                Month = int.Parse(value[2..4], CultureInfo.CurrentCulture);
                Day = int.Parse(value[4..6], CultureInfo.CurrentCulture);
                Sequence1 = value[7];
                Gender = value[8];
                Sequence2 = value[9];
                break;
            case LongLength:
                Kind = RegionSkaneLocalReserveNumberKind.Long;
                Year = int.Parse(value[0..4], CultureInfo.CurrentCulture);
                Month = int.Parse(value[4..6], CultureInfo.CurrentCulture);
                Day = int.Parse(value[6..8], CultureInfo.CurrentCulture);
                Sequence1 = value[9];
                Gender = value[10];
                Sequence2 = value[11];
                break;
            default:
                throw new ArgumentException("Invalid length", nameof(value));
        }
    }

    public RegionSkaneLocalReserveNumberKind Kind { get; }

    public int Year { get; }

    public int Month { get; }

    public int Day { get; }

    public char Sequence1 { get; }

    public char Gender { get; }

    public char Sequence2 { get; }

    public override IEnumerator<(string Name, object Value)> GetEnumerator()
    {
        yield return (Name: nameof(Kind), Value: Kind);
        yield return (Name: nameof(Year), Value: Year);
        yield return (Name: nameof(Month), Value: Month);
        yield return (Name: nameof(Day), Value: Day);
        yield return (Name: nameof(Sequence1), Value: Sequence1);
        yield return (Name: nameof(Gender), Value: Gender);
        yield return (Name: nameof(Sequence2), Value: Sequence2);
    }
}
