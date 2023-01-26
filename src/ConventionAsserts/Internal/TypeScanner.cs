using ConventionAsserts.Infrastructure;

namespace ConventionAsserts.Internal;

public class TypeScanner : ConventionTypeSource, ITypeScanner, ITypeScannerFilter
{
    public ITypeScannerFilter FromAssemblyContaining<T>()
    {
        Types = typeof(T).Assembly.GetTypes();
        return this;
    }

    public ITypeScannerFilter Where(Func<ITypeFilter, bool> predicate)
    {
        GuardAgainst.Null(predicate);

        Types = Types
            .Select(x => new TypeFilter(x))
            .Where(x => predicate(x))
            .Select(x => x.Type)
            .ToList();
        return this;
    }

    public void Assert(Action<ITypeAssert> assert)
    {
        GuardAgainst.Null(assert);

        var typeAssert = new TypeAssert(this);
        assert(typeAssert);
    }
}
