using System;
using System.Collections.Generic;
using System.Linq;
using PersonIdentifiers.Swedish.Internal;

namespace PersonIdentifiers.Swedish.Tests.Conventions.TestHelpers.Conventions;

public class PersonIdentifierPartTypesMustEnumerateAllProperties : TypeConvention
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

        // TODO: Zip limits to the shorter list
        var elements = instance
            .Zip(properties, (part, property) => (Part: part, Property: property))
            .ToList();
        foreach (var element in elements)
        {
            var elementName = element.Property.Name;
            if (elementName != element.Part.Name)
            {
                var partNames = elements
                    .Select(x => x.Part.Name)
                    .ToList();
                if (partNames.Contains(elementName))
                {
                    Fail(type, $"must return part named {elementName} in correct sequence");
                }

                Fail(type, $"must return part named {elementName}");
            }
        }
    }
}
