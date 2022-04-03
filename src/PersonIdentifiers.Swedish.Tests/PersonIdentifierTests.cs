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

    [Fact]
    public void CanGetHashCode()
    {
        var identifier1 = PersonIdentifier.Parse("191212121212");
        var identifier2 = PersonIdentifier.Parse("191212121212");

        var hashCode1 = identifier1.GetHashCode();
        var hashCode2 = identifier2.GetHashCode();

        Assert.Equal(hashCode1, hashCode2);
    }

    [Fact]
    public void CanEqualsTrue()
    {
        var identifier1 = PersonIdentifier.Parse("191212121212");
        var identifier2 = PersonIdentifier.Parse("191212121212");

        var isEqual = identifier1.Equals(identifier2);

        Assert.True(isEqual);
    }

    [Fact]
    public void CanEqualsObjectTrue()
    {
        var identifier1 = (object)PersonIdentifier.Parse("191212121212");
        var identifier2 = (object)PersonIdentifier.Parse("191212121212");

        var isEqual = identifier1.Equals(identifier2);

        Assert.True(isEqual);
    }

    [Fact]
    public void CanEqualsNullFalse()
    {
        var identifier1 = PersonIdentifier.Parse("191212121212");
        var identifier2 = (PersonIdentifier)null!;

        var isEqual = identifier1.Equals(identifier2);

        Assert.False(isEqual);
    }

    [Fact]
    public void CanEqualsObjectFalse()
    {
        var identifier1 = PersonIdentifier.Parse("191212121212");
        var identifier2 = new object();

        var isEqual = identifier1.Equals(identifier2);

        Assert.False(isEqual);
    }
}
