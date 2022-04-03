using PersonIdentifiers.Swedish.Internal;
using PersonIdentifiers.Swedish.Tests.TestHelpers;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests;

public class CoordinationNumberTests
{
    [Fact]
    public void CanGetOid()
    {
        var identifier = CoordinationNumber.Parse("197010632391");
        Assert.Equal(PersonIdentifierOids.CoordinationNumber, identifier.Oid);
    }

    [Fact]
    public void ThrowsOnNullDateOfBirth()
    {
        var identifier = CoordinationNumber.Parse("197010632391");
        var baseIdentifier = (PersonIdentifier)identifier;
        baseIdentifier.Set(x => x.DateOfBirth, default);

        Assert.Throws<UnreachableCodeException>(() => identifier.DateOfBirth);
    }

    [Fact]
    public void ThrowsOnNullGender()
    {
        var identifier = CoordinationNumber.Parse("197010632391");
        var baseIdentifier = (PersonIdentifier)identifier;
        baseIdentifier.Set(x => x.Gender, default);

        Assert.Throws<UnreachableCodeException>(() => identifier.Gender);
    }
}
