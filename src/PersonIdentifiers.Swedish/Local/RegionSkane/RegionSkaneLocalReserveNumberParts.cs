using System.Globalization;
using PersonIdentifiers.Swedish.Internal;
using PersonIdentifiers.Swedish.Parts;

namespace PersonIdentifiers.Swedish.Local.RegionSkane;

public class RegionSkaneLocalReserveNumberParts : PersonIdentifierParts
{
    public RegionSkaneLocalReserveNumberParts(string value)
    {
        GuardAgainst.Null(value);

        Year = int.Parse(value[0..4], CultureInfo.CurrentCulture);
        Month = int.Parse(value[4..6], CultureInfo.CurrentCulture);
        Day = int.Parse(value[6..8], CultureInfo.CurrentCulture);
        Sequence1 = value[9];
        Gender = value[10];
        Sequence2 = value[11];
    }

    public int Year { get; }

    public int Month { get; }

    public int Day { get; }

    public char Sequence1 { get; }

    public char Gender { get; }

    public char Sequence2 { get; }

    public override IEnumerator<(string Name, object Value)> GetEnumerator()
    {
        yield return (Name: nameof(Year), Value: Year);
        yield return (Name: nameof(Month), Value: Month);
        yield return (Name: nameof(Day), Value: Day);
        yield return (Name: nameof(Sequence1), Value: Sequence1);
        yield return (Name: nameof(Gender), Value: Gender);
        yield return (Name: nameof(Sequence2), Value: Sequence2);
    }
}
