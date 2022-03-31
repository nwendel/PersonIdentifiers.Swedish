using Xunit;

namespace PersonIdentifiers.Swedish.Tests;

public class PersonIdentifierOidsTests
{
    [Theory]
    [InlineData(PersonIdentifierKind.PersonalIdentityNumber, PersonIdentifierOids.PersonalNumber)]
    [InlineData(PersonIdentifierKind.CoordinationNumber, PersonIdentifierOids.CoordinationNumber)]
    [InlineData(PersonIdentifierKind.NationalReserveNumber, PersonIdentifierOids.NationalReserveNumber)]
    public void CanGetOid(PersonIdentifierKind kind, string expectedOid)
    {
        var oid = PersonIdentifierOids.GetOid(kind);
        Assert.Equal(expectedOid, oid);
    }
}
