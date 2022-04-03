using PersonIdentifiers.Swedish.Internal;
using PersonIdentifiers.Swedish.Tests.TestHelpers;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests;

public class PersonalIdentityNumberTests
{
    [Fact]
    public void CanGetOid()
    {
        var identifier = PersonalIdentityNumber.Parse("191212121212");
        Assert.Equal(PersonIdentifierOids.PersonalIdentityNumber, identifier.Oid);
    }

    [Fact]
    public void ThrowsOnNullDateOfBirth()
    {
        var identifier = PersonalIdentityNumber.Parse("191212121212");
        var baseIdentifier = (PersonIdentifier)identifier;
        baseIdentifier.Set(x => x.DateOfBirth, default);

        Assert.Throws<UnreachableCodeException>(() => identifier.DateOfBirth);
    }

    [Fact]
    public void ThrowsOnNullGender()
    {
        var identifier = PersonalIdentityNumber.Parse("191212121212");
        var baseIdentifier = (PersonIdentifier)identifier;
        baseIdentifier.Set(x => x.Gender, default);

        Assert.Throws<UnreachableCodeException>(() => identifier.Gender);
    }
}
