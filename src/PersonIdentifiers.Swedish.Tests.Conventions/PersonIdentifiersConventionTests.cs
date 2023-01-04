using System;
using System.Collections.Generic;
using System.Linq;
using ArchUnit;
using ArchUnit.Rules;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests.Conventions;

public class PersonIdentifiersConventionTests
{
    private static readonly IEnumerable<Type> _personIdentifierTypes =
        typeof(PersonIdentifier).Assembly
        .GetTypes()
        .Where(x => x.IsAssignableTo(typeof(PersonIdentifier)))
        .ToList();

    [Fact]
    public void IsSealedOrAbstract()
    {
        ConventionAssert.TypesFollow<IsAbstractOrSealed>(_personIdentifierTypes);
    }

    [Fact]
    public void NoPublicConstructor()
    {
        ConventionAssert.TypesFollow<NoPublicConstructors>(_personIdentifierTypes);
    }
}
