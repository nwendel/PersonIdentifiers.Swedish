using System;
using System.Collections.Generic;
using System.Linq;
using PersonIdentifiers.Swedish.Local;
using PersonIdentifiers.Swedish.Tests.Conventions.TestHelpers;
using PersonIdentifiers.Swedish.Tests.Conventions.TestHelpers.Conventions;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests.Conventions;

public class PersonIdentifiersParseConventionTests
{
    private static readonly IEnumerable<Type> _personIdentifierTypes = typeof(PersonIdentifier).Assembly
        .GetTypes()
        .Where(x => x.IsAssignableTo(typeof(PersonIdentifier)))
        .ToList();

    private static readonly IEnumerable<Type> _personIdentifierTypesExceptLocal = _personIdentifierTypes
        .Where(x => x != typeof(LocalReserveNumber))
        .ToList();

    [Fact]
    public void HasStaticParseMethod()
    {
        ConventionAssert.TypesFollow<PersonIdentifierTypesMustHaveStaticParseMethod>(_personIdentifierTypesExceptLocal);
    }

    [Fact]
    public void HasStaticTryParseMethod()
    {
        ConventionAssert.TypesFollow<PersonIdentifierTypesMustHaveStaticParseMethod>(_personIdentifierTypesExceptLocal);
    }

    [Fact]
    public void IsSealedOrAbstract()
    {
        ConventionAssert.TypesFollow<PersonIdentifierTypesMustBeAbstractOrSealed>(_personIdentifierTypes);
    }
}
