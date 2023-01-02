using ArchUnit.Infrastructure;
using ArchUnit.Internal;

namespace ArchUnit;

public static class ConventionAssert
{
    public static void TypesFollow<T>(IEnumerable<Type> types)
        where T : TypeConvention, IInitializeConvention, new()
    {
        GuardAgainst.Null(types);

        var context = new ConventionContext();
        var convention = new T();
        convention.Initialize(context);

        foreach (var type in types)
        {
            try
            {
                convention.Assert(type);
            }
            catch (ConventionFailedException)
            {
                continue;
            }
        }

        var messages = convention.Context.Messages;
        if (messages.Any())
        {
            var message = string.Join(Environment.NewLine, messages);

            // TODO: Change to ConventionException and figure out how the formatting works
            throw new ConventionException(message);
        }
    }
}
