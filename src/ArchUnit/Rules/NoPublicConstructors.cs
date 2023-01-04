using ArchUnit.Infrastructure;

namespace ArchUnit.Rules;

public class NoPublicConstructors : ITypeConvention
{
    public void Assert(Type type, ConventionContext context)
    {
        GuardAgainst.Null(type);

        if (type.GetConstructors().Any())
        {
            context.Fail(type, "must not have a public constructor");
        }
    }
}
