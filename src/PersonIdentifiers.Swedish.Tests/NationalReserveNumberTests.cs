using Xunit;

namespace PersonIdentifiers.Swedish.Tests;

public class NationalReserveNumberTests
{
    [Fact]
    public void CanGetOid()
    {
        var identifier = NationalReserveNumber.Parse("22790814AA01");
        Assert.Equal(PersonIdentifierOids.NationalReserveNumber, identifier.Oid);
    }
}
