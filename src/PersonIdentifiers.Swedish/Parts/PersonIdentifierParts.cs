using System.Collections;

namespace PersonIdentifiers.Swedish.Parts;

public abstract class PersonIdentifierParts : IEnumerable<(string Name, object Value)>
{
    // TODO: Possibly implement this here using reflection?
    public abstract IEnumerator<(string Name, object Value)> GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
