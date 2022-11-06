using System;
using PersonIdentifiers.Swedish.Internal;

namespace PersonIdentifiers.Swedish.Tests.Conventions.TestHelpers.Conventions;

public class PersonIdentifierTypesMustHaveStaticTryParseMethod : TypeConvention
{
    public override void Assert(Type type)
    {
        GuardAgainst.Null(type);

        var method = type.GetMethod(nameof(PersonIdentifier.TryParse), System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static, new[] { typeof(string), type.MakeByRefType() });
        if (method == null)
        {
            Fail(type, $"must have a public static method named {nameof(PersonIdentifier.TryParse)}");
        }

        if (method.ReturnType != typeof(bool))
        {
            Fail(type, method, $"must return type {typeof(bool).Name}");
        }
    }
}
