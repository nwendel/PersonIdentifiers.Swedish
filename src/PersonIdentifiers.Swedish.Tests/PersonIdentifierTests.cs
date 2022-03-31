using Xunit;

namespace PersonIdentifiers.Swedish.Tests;

public class PersonIdentifierTests
{
    [Fact]
    public void CanToString()
    {
        var personalIdentityNumber = "191212121212";
        var identifier = PersonIdentifier.Parse(personalIdentityNumber);

        Assert.Equal(personalIdentityNumber, identifier.ToString());
    }
}
