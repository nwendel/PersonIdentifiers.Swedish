namespace ArchUnit;

public interface ITypeConvention
{
    void Assert(Type type, ConventionContext context);
}
