namespace PersonIdentifiers.Swedish;

public interface IPersonIdentifierPartsAware<T>
    where T : IPersonIdentifierParts
{
    T Parts { get; }
}
