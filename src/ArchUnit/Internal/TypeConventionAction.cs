namespace ArchUnit.Internal;

public class TypeConventionAction : ITypeConvention
{
    private readonly Action<Type, ConventionContext> action;

    public TypeConventionAction(Action<Type, ConventionContext> action)
    {
        this.action = action;
    }

    public void Assert(Type item, ConventionContext context)
    {
        action(item, context);
    }
}
