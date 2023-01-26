using System.Diagnostics.CodeAnalysis;
using ConventionAsserts.Infrastructure.TestFrameworks;

namespace ConventionAsserts.Infrastructure;

internal static class TestFramework
{
    private static readonly ITestFramework[] _frameworks = new[]
    {
        new XunitTestFramework(),
    };

    private static ITestFramework? _detected;

    private static ITestFramework Detected
    {
        get
        {
            if (_detected == null)
            {
                // TODO: Is Single correct here?
                _detected = _frameworks.SingleOrDefault(x => x.IsAvailable);
                _detected ??= new UnknownTestFramework();
            }

            return _detected;
        }
    }

    [DoesNotReturn]
    public static void Throw(string message)
    {
        Detected.Throw(message);
    }
}
