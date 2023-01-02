using System;
using System.Collections.Generic;
using System.Linq;
using PersonIdentifiers.Swedish.Internal;
using PersonIdentifiers.Swedish.Tests.Conventions.TestHelpers;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests.Conventions;

public class PersonIdentifiersParseConventionTests
{
    private static readonly IEnumerable<Type> _personIdentifierTypes =
        typeof(PersonIdentifier).Assembly
        .GetTypes()
        .Where(x => x.IsAssignableTo(typeof(PersonIdentifier)))
        .ToList();

    [Fact]
    public void HasStaticParseMethod()
    {
        ConventionAssert.TypesFollow<PersonIdentifierTypesMustHaveStaticParseMethod>(_personIdentifierTypes);
    }

    [Fact]
    public void HasStaticTryParseMethod()
    {
        ConventionAssert.TypesFollow<PersonIdentifierTypesMustHaveStaticTryParseMethod>(_personIdentifierTypes);
    }

    private sealed class PersonIdentifierTypesMustHaveStaticParseMethod : TypeConvention
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

    private sealed class PersonIdentifierTypesMustHaveStaticTryParseMethod : TypeConvention
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
}
