using System.Linq;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests;

public class PersonIdentifierOidsTests
{
    [Theory]
    [InlineData(PersonIdentifierKind.PersonalIdentityNumber, PersonIdentifierOids.PersonalIdentityNumber)]
    [InlineData(PersonIdentifierKind.CoordinationNumber, PersonIdentifierOids.CoordinationNumber)]
    [InlineData(PersonIdentifierKind.NationalReserveNumber, PersonIdentifierOids.NationalReserveNumber)]
    public void CanGetOid(PersonIdentifierKind kind, string expectedOid)
    {
        var oid = PersonIdentifierOids.GetOid(kind);
        Assert.Equal(expectedOid, oid);
    }

    [Fact]
    public void OidsAreUnique()
    {
        var identifiers = new PersonIdentifier[]
        {
            PersonalIdentityNumber.Parse("191212121212"),
            CoordinationNumber.Parse("197010632391"),
            NationalReserveNumber.Parse("22790814AA01"),
        };

        var oids = identifiers
            .Select(x => x.Oid)
            .Distinct()
            .ToList();

        Assert.Equal(identifiers.Length, oids.Count);
    }
}
