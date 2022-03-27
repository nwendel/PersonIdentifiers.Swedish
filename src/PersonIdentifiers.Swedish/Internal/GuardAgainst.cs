using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace PersonIdentifiers.Swedish.Internal;

public static class GuardAgainst
{
    public static void Null<T>([NotNull] T? value, [CallerArgumentExpression("value")] string? argumentName = null)
        where T : class
    {
        if (value == null)
        {
            throw new ArgumentNullException(argumentName);
        }
    }

    public static void Condition([DoesNotReturnIf(true)] bool condition, string message, string argumentName)
    {
        if (condition)
        {
            throw new ArgumentException(message, argumentName);
        }
    }
}
