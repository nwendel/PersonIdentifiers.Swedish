using System;
using System.Collections.Generic;
using System.Linq;
using ConventionAssertions;
using PersonIdentifiers.Swedish.Parts;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests.Conventions;

public class PersonIdentifiersPartsTests
{
    private static readonly ConventionTypeSource _typeSource = Convention
        .ForTypes(x => x
            .FromAssemblyContaining<PersonIdentifierParts>()
            .Where(t => t.AssignableTo<PersonIdentifierParts>() &&
                        !t.Type.IsAbstract));

    [Fact]
    public void CanEnumerateParts()
    {
        Convention.ForTypes(
            _typeSource,
            x => x.Assert((type, context) =>
            {
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
                        context.Fail(type, $"must not return {instance.ElementAt(ix).Name} since there is no property with same name when enumerating");
                    }

                    if (instance.Count() < ix + 1)
                    {
                        context.Fail(type, $"must return {properties[ix].Name} when enumerating");
                    }

                    var propertyName = properties[ix].Name;
                    var partName = instance.ElementAt(ix).Name;
                    if (propertyName != partName)
                    {
                        context.Fail(type, $"must return {propertyName} in correct sequence when enumerating");
                    }
                }
            }));
    }
}
