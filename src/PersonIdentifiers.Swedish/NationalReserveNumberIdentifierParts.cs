namespace PersonIdentifiers.Swedish;

public class NationalReserveNumberIdentifierParts : StandardPersonIdentifierParts
{
    public NationalReserveNumberIdentifierParts(string value)
        : base(value)
    {
        SequenceAndGender = value[8..11];
    }

    public string SequenceAndGender { get; }
}
