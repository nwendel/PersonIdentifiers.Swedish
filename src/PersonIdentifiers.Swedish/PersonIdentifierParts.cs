using System.Collections;

namespace PersonIdentifiers.Swedish;

public abstract class PersonIdentifierParts : IEnumerable<(string Name, object Value)>
{
    public abstract IEnumerator<(string Name, object Value)> GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
