using System;
using PersonIdentifiers.Swedish.Internal;

namespace PersonIdentifiers.Swedish.Tests.Conventions.TestHelpers.Conventions;

public class PersonIdentifierTypesMustHaveStaticTryParseMethod : TypeConvention
{
    public override void Assert(Type type)
    {
        GuardAgainst.Null(type);

        var method = type.GetMethod(nameof(PersonIdentifier.Parse), System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static, new[] { typeof(string), type });
        if (method == null)
        {
            Fail(type, $"must have a public static method named {nameof(PersonIdentifier.Parse)}");
        }

        if (method.ReturnType != typeof(bool))
        {
            Fail(type, method, $"must return type {typeof(bool).Name}");
        }
    }
}
