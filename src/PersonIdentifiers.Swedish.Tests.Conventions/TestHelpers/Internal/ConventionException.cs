using System;

namespace PersonIdentifiers.Swedish.Tests.Conventions.TestHelpers.Internal;

// TODO: How to make xunit format this exception correctly?
public class ConventionException : Exception
{
    public ConventionException(string message)
        : base(message)
    {
    }
}
