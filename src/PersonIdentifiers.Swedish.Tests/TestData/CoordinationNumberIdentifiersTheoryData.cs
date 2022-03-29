using NodaTime;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests.TestData;

public class CoordinationNumberIdentifiersTheoryData : TheoryData<string, PersonIdentifierKind, LocalDate?, PersonIdentifierGender?>
{
    public CoordinationNumberIdentifiersTheoryData()
    {
        Add("197010632391", PersonIdentifierKind.CoordinationNumber, new LocalDate(1970, 10, 3), PersonIdentifierGender.Male);
        Add("197010632383", PersonIdentifierKind.CoordinationNumber, new LocalDate(1970, 10, 3), PersonIdentifierGender.Female);
    }
}
