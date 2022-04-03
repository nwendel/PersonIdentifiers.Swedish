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
}
