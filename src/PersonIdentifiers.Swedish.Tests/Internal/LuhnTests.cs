using System.Linq;
using NodaTime;
using PersonIdentifiers.Swedish.Internal;
using PersonIdentifiers.Swedish.Tests.TestData;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests.Internal;

public class LuhnTests
{
    [Theory]
    [ClassData(typeof(PersonalNumberIdentifiersTheoryData))]
    [ClassData(typeof(CoordinationNumberIdentifiersTheoryData))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "xUnit1026:Theory methods should use all of their parameters", Justification = "Common test data for multiple tests")]
    public void CanIsValidTrue(string value, PersonIdentifierKind kind, LocalDate? dateOfBirth, PersonIdentifierGender? gender)
    {
        Assert.True(Luhn.IsValid(value[2..]));
    }

    [Theory]
    [ClassData(typeof(PersonalNumberIdentifiersTheoryData))]
    [ClassData(typeof(CoordinationNumberIdentifiersTheoryData))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "xUnit1026:Theory methods should use all of their parameters", Justification = "Common test data for multiple tests")]
    public void CanCalculate(string value, PersonIdentifierKind kind, LocalDate? dateOfBirth, PersonIdentifierGender? gender)
    {
        var checkDigit = Luhn.Calculate(value[2..^1]);
        var expectedCheckDigit = value.Last() - '0';

        Assert.Equal(expectedCheckDigit, checkDigit);
    }
}
