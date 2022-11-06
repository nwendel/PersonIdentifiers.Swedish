namespace PersonIdentifiers.Swedish.Parts;

public interface IPersonIdentifierPartsAware<T>
    where T : PersonIdentifierParts
{
    T Parts { get; }
}
