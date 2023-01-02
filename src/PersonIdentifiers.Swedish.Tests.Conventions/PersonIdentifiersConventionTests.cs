using System;
using System.Collections.Generic;
using System.Linq;
using ArchUnit;
using PersonIdentifiers.Swedish.Internal;
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
        ConventionAssert.TypesFollow<PersonIdentifierTypesMustBeAbstractOrSealed>(_personIdentifierTypes);
    }

    private sealed class PersonIdentifierTypesMustBeAbstractOrSealed : TypeConvention
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
}
