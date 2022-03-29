using System.Globalization;
using PersonIdentifiers.Swedish.Internal;

namespace PersonIdentifiers.Swedish;

public class StandardPersonIdentifierParts : IPersonIdentifierParts
{
    public StandardPersonIdentifierParts(string value)
    {
        GuardAgainst.Null(value);
        GuardAgainst.Condition(value.Length != 12, "Invalid length", nameof(value));

        Century = int.Parse(value[0..2], CultureInfo.CurrentCulture);
        Year = int.Parse(value[0..4], CultureInfo.CurrentCulture);
        Month = int.Parse(value[4..6], CultureInfo.CurrentCulture);
        Day = int.Parse(value[6..8], CultureInfo.CurrentCulture);
        Date = value[0..8];
        Sequence = value[8..10];
        Gender = value[10];
        CheckDigit = value[11];
    }

    public int Century { get; }

    public int Year { get; }

    public int Month { get; }

    public int Day { get; }

    public string Date { get; }

    public string Sequence { get; }

    public char Gender { get; }

    public char CheckDigit { get; }
}
