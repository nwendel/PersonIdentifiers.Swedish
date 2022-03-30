using System.Collections.Generic;

namespace PersonIdentifiers.Swedish.Tests.Conventions.TestHelpers.Internal;

public class ConventionContext
{
    private readonly List<string> _messages = new();

    public IEnumerable<string> Messages => _messages;

    public void Add(string message)
    {
        _messages.Add(message);
    }
}
