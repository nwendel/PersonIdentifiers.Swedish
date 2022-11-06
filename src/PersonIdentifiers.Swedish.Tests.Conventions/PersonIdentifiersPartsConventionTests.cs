using System;
using System.Collections.Generic;
using System.Linq;
using PersonIdentifiers.Swedish.Parts;
using PersonIdentifiers.Swedish.Tests.Conventions.TestHelpers;
using PersonIdentifiers.Swedish.Tests.Conventions.TestHelpers.Conventions;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests.Conventions;

public class PersonIdentifiersPartsConventionTests
{
    private static readonly IEnumerable<Type> _personIdentifierPartsTypes =
        typeof(PersonIdentifierParts).Assembly
        .GetTypes()
        .Where(x => x.IsAssignableTo(typeof(PersonIdentifierParts)) &&
                    !x.IsAbstract)
        .ToList();

    [Fact]
    public void CanEnumerateParts()
    {
        ConventionAssert.TypesFollow<PersonIdentifierPartTypesMustEnumerateAllProperties>(_personIdentifierPartsTypes);
    }
}
