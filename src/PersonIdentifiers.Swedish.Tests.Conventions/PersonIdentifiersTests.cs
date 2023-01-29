using ConventionAssertions;
using ConventionAssertions.Rules;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests.Conventions;

public class PersonIdentifiersTests
{
    private static readonly ConventionTypeSource _typeSource = Convention
        .ForTypes(x => x
            .FromAssemblyContaining<PersonIdentifier>()
            .Where(t => t.AssignableTo<PersonIdentifier>()));

    [Fact]
    public void IsSealedOrAbstract()
    {
        Convention.ForTypes(
            _typeSource,
            x => x.Assert<IsAbstractOrSealed>());
    }

    [Fact]
    public void NoPublicConstructor()
    {
        Convention.ForTypes(
            _typeSource,
            x => x.Assert<NoPublicConstructors>());
    }

    [Fact]
    public void HasPublicStaticParseMethod()
    {
        Convention.ForTypes(
            _typeSource,
            x => x.Assert<HasPublicStaticParseMethod>());
    }

    [Fact]
    public void HasStaticTryParseMethod()
    {
        Convention.ForTypes(
            _typeSource,
            x => x.Assert<HasPublicStaticTryParseMethod>());
    }
}
