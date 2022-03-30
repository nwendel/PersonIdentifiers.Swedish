namespace PersonIdentifiers.Swedish;

public interface IPersonIdentifierPartsAware<T>
    where T : PersonIdentifierParts
{
    T Parts { get; }
}
