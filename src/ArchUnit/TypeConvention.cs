namespace ArchUnit;

public abstract class TypeConvention : Convention
{
    public abstract void Assert(Type type);
}
