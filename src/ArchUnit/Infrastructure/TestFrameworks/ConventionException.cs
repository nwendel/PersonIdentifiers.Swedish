﻿namespace ArchUnit.Infrastructure.TestFrameworks;

public class ConventionException : Exception
{
    public ConventionException(string message)
        : base(message)
    {
    }
}
