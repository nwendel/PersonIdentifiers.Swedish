namespace PersonIdentifiers.Swedish;

public class NationalReserveNumberIdentifierParts : StandardPersonIdentifierParts
{
    public NationalReserveNumberIdentifierParts(string value)
        : base(value)
    {
        SequenceAndGender = value[8..11];
    }

    // TODO: This should fail the convention unit tests
    public string SequenceAndGender { get; }
}
