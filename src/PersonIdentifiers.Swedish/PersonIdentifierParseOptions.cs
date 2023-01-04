using PersonIdentifiers.Swedish.LocalReserveNumbers;

namespace PersonIdentifiers.Swedish;

public class PersonIdentifierParseOptions
{
    private PersonIdentifierParseOptions()
    {
    }

    // TODO: Always create new instance hereor have public constructor?
    //       Allow changing of "Default"?
    public static PersonIdentifierParseOptions Default => new();

    public LocalReserveNumberPrincipal? LocalReserveNumberPrincipal { get; set; }
}
