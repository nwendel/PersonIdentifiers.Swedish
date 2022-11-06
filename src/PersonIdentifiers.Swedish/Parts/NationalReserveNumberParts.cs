namespace PersonIdentifiers.Swedish.Parts;

public class NationalReserveNumberParts : StandardPersonIdentifierParts
{
    public NationalReserveNumberParts(string value)
        : base(value)
    {
        SequenceAndGender = value[8..11];
    }

    public string SequenceAndGender { get; }

    public override IEnumerator<(string Name, object Value)> GetEnumerator()
    {
        yield return (Name: nameof(SequenceAndGender), Value: SequenceAndGender);

        var enumerator = base.GetEnumerator();
        while (enumerator.MoveNext())
        {
            yield return enumerator.Current;
        }
    }
}
