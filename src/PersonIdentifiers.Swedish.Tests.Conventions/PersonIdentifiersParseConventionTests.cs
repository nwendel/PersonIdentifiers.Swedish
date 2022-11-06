using System;
using System.Collections.Generic;
using System.Linq;
using PersonIdentifiers.Swedish.Tests.Conventions.TestHelpers;
using PersonIdentifiers.Swedish.Tests.Conventions.TestHelpers.Conventions;
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

    [Fact]
    public void IsSealedOrAbstract()
    {
        ConventionAssert.TypesFollow<PersonIdentifierTypesMustBeAbstractOrSealed>(_personIdentifierTypes);
    }
}
