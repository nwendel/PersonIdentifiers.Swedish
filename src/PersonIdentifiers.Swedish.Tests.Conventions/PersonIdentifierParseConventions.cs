using System.Linq;
using PersonIdentifiers.Swedish.Tests.Conventions.TestHelpers;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests.Conventions;

public class PersonIdentifierParseConventions
{
    [Fact]
    public void HasParseMethod()
    {
        var assembly = typeof(PersonIdentifier).Assembly;
        var types = assembly.GetTypes()
            .Where(x => x.IsAssignableTo(typeof(PersonIdentifier)))
            .ToList();

        foreach (var type in types)
        {
            var method = type.GetMethod(nameof(PersonIdentifier.Parse), System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static, new[] { typeof(string) });
            if (method == null)
            {
                throw new ConventionException($"Type {type.Name} does not have a public static method named {nameof(PersonIdentifier.Parse)}");
            }

            if (method.ReturnType != type)
            {
                throw new ConventionException($"Type {type.Name} method {nameof(PersonIdentifier.Parse)} does not return type {type.Name}");
            }
        }
    }
}
