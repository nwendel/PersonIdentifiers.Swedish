using System;
using PersonIdentifiers.Swedish.Internal;

namespace PersonIdentifiers.Swedish.Tests.Conventions.TestHelpers.Conventions;

public class PersonIdentifierTypesMustBeAbstractOrSealed : TypeConvention
{
    public override void Assert(Type type)
    {
        GuardAgainst.Null(type);

        if (type.IsAbstract || type.IsSealed)
        {
            return;
        }

        Fail(type, $"must be abstract or sealed");
    }
}
