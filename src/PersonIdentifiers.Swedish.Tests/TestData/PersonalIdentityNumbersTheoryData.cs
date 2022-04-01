using System;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests.TestData;

public class PersonalIdentityNumbersTheoryData : TheoryData<string, PersonIdentifierKind, DateOnly?, PersonIdentifierGender?>
{
    public PersonalIdentityNumbersTheoryData()
    {
        Add("191212121212", PersonIdentifierKind.PersonalIdentityNumber, new DateOnly(1912, 12, 12), PersonIdentifierGender.Male);
        Add("200101010106", PersonIdentifierKind.PersonalIdentityNumber, new DateOnly(2001, 1, 1), PersonIdentifierGender.Female);
    }
}
