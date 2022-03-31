namespace PersonIdentifiers.Swedish.Local;

public abstract class LocalReserveNumber : PersonIdentifier
{
    protected LocalReserveNumber(string value, PersonIdentifierParts parts)
        : base(value, parts)
    {
    }

    public override PersonIdentifierKind Kind => PersonIdentifierKind.LocalReserveNumber;

    public abstract LocalReserveNumberPrincipal Principal { get; }
}
