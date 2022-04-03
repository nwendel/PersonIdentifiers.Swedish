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
}
