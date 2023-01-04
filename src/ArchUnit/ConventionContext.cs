using System.Diagnostics.CodeAnalysis;
using ArchUnit.Infrastructure;
using ArchUnit.Internal;

namespace ArchUnit;

public class ConventionContext
{
    private readonly List<string> _messages = new();

    public IEnumerable<string> Messages => _messages;

    [DoesNotReturn]
    public void Fail(Type type, string message)
    {
        GuardAgainst.Null(type);
        GuardAgainst.NullOrWhiteSpace(message);

        _messages.Add($"Type {type.Name} {message}");
        throw new ConventionFailedException();
    }
}
