namespace PersonIdentifiers.Swedish.Options;

public class PersonIdentifierParseOptions
{
    private PersonIdentifierParseOptions()
    {
    }

    // TODO: Always create new instance here?
    public static PersonIdentifierParseOptions Default => new();

    public bool AllowLocal { get; set; }
}
