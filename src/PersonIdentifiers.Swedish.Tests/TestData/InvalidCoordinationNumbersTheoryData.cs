using NodaTime;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests.TestData;

public class InvalidCoordinationNumbersTheoryData : TheoryData<string, PersonIdentifierKind, LocalDate?, PersonIdentifierGender?>
{
    public InvalidCoordinationNumbersTheoryData()
    {
        Add("197013632398", PersonIdentifierKind.CoordinationNumber, null, null); // Invalid month
        Add("197010632390", PersonIdentifierKind.CoordinationNumber, null, null); // Invalid check digit
    }
}
