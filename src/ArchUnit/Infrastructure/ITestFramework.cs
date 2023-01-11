using System.Diagnostics.CodeAnalysis;

namespace ArchUnit.Infrastructure;

internal interface ITestFramework
{
    bool IsAvailable { get; }

    [DoesNotReturn]
    void Throw(string message);
}
