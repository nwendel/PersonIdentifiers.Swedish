using System;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests.TestData;

public class CoordinationNumbersTheoryData : TheoryData<string, PersonIdentifierKind, DateOnly?, PersonIdentifierGender?>
{
    public CoordinationNumbersTheoryData()
    {
        Add("197010632391", PersonIdentifierKind.CoordinationNumber, new DateOnly(1970, 10, 3), PersonIdentifierGender.Male);
        Add("197010632383", PersonIdentifierKind.CoordinationNumber, new DateOnly(1970, 10, 3), PersonIdentifierGender.Female);
    }
}
