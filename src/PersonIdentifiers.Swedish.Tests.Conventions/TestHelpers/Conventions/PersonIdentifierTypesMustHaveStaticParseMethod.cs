using System;
using PersonIdentifiers.Swedish.Internal;

namespace PersonIdentifiers.Swedish.Tests.Conventions.TestHelpers.Conventions;

public class PersonIdentifierTypesMustHaveStaticParseMethod : TypeConvention
{
    public override void Assert(Type type)
    {
        GuardAgainst.Null(type);

        var method = type.GetMethod(nameof(PersonIdentifier.Parse), System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static, new[] { typeof(string) });
        if (method == null)
        {
            Fail(type, $"must have a public static method named {nameof(PersonIdentifier.Parse)}");
        }

        if (method.ReturnType != type)
        {
            Fail(type, method, $"must return type {type.Name}");
        }
    }
}
