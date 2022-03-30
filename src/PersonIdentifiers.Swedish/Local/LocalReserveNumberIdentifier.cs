namespace PersonIdentifiers.Swedish.Local;

public abstract class LocalReserveNumberIdentifier : PersonIdentifier
{
    protected LocalReserveNumberIdentifier(string value, PersonIdentifierParts parts)
        : base(value, parts)
    {
    }

    public override PersonIdentifierKind Kind => PersonIdentifierKind.LocalReserveNumber;

    public abstract LocalReserveNumberPrincipal Principal { get; }
}
