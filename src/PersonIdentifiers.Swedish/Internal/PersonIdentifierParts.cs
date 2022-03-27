namespace PersonIdentifiers.Swedish.Internal;

public class PersonIdentifierParts
{
    private string _value;

    public PersonIdentifierParts(string value)
    {
        _value = value;
    }

    public string Century => _value[0..2];

    public string Year => _value[0..4];

    public string Month => _value[4..6];

    public string Day => _value[6..8];

    public string Date => _value[0..8];

    public string Sequence => _value[8..10];

    public string Gender => _value[10..11];

    public string CheckDigit => _value[11..12];
}
