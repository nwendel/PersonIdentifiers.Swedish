using System;
using System.Collections.Generic;
using System.Linq;
using PersonIdentifiers.Swedish.Internal;
using PersonIdentifiers.Swedish.Parts;
using PersonIdentifiers.Swedish.Tests.Conventions.TestHelpers;
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

    private sealed class PersonIdentifierPartTypesMustEnumerateAllProperties : TypeConvention
    {
        public override void Assert(Type type)
        {
            GuardAgainst.Null(type);

            var instance = (IEnumerable<(string Name, object Value)>?)Activator.CreateInstance(type, "191212121212");
            if (instance == null)
            {
                throw new InvalidOperationException("No instance created");
            }

            var properties = type.GetProperties();

            var length = Math.Max(instance.Count(), properties.Length);
            for (var ix = 0; ix < length; ix++)
            {
                if (properties.Length < ix + 1)
                {
                    Fail(type, $"must not return {instance.ElementAt(ix).Name} since there is no property with same name when enumerating");
                }

                if (instance.Count() < ix + 1)
                {
                    Fail(type, $"must return {properties[ix].Name} when enumerating");
                }

                var propertyName = properties[ix].Name;
                var partName = instance.ElementAt(ix).Name;
                if (propertyName != partName)
                {
                    Fail(type, $"must return {propertyName} in correct sequence when enumerating");
                }
            }
        }
    }
}
