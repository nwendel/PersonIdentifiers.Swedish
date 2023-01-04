using ArchUnit.Infrastructure;
using ArchUnit.Internal;

namespace ArchUnit;

public static class ConventionAssert
{
    public static void TypesFollow(IEnumerable<Type> types, Action<Type, ConventionContext> assertAction)
    {
        var convention = new TypeConventionAction(assertAction);
        TypesFollow(types, convention);
    }

    public static void TypesFollow<T>(IEnumerable<Type> types)
        where T : ITypeConvention, new()
    {
        GuardAgainst.Null(types);

        var convention = new T();
        TypesFollow(types, convention);
    }

    public static void TypesFollow(IEnumerable<Type> types, ITypeConvention convention)
    {
        GuardAgainst.Null(types);
        GuardAgainst.Null(convention);

        var context = new ConventionContext();
        foreach (var type in types)
        {
            try
            {
                convention.Assert(type, context);
            }
            catch (ConventionFailedException)
            {
                // Ignore this exception
            }
        }

        var messages = context.Messages;
        if (messages.Any())
        {
            var message = string.Join(Environment.NewLine, messages);

            // TODO: Change to ConventionException and figure out how the formatting works
            throw new ConventionException(message);
        }
    }
}
