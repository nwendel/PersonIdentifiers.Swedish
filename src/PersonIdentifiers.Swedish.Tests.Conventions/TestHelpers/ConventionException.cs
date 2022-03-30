using System;

namespace PersonIdentifiers.Swedish.Tests.Conventions.TestHelpers;

public class ConventionException : Exception
{
    public ConventionException(string message)
        : base(message)
    {
    }
}
