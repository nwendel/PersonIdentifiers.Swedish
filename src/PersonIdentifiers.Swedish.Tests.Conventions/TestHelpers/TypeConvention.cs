using System;

namespace PersonIdentifiers.Swedish.Tests.Conventions.TestHelpers;

public abstract class TypeConvention : Convention
{
    public abstract void Assert(Type type);
}
