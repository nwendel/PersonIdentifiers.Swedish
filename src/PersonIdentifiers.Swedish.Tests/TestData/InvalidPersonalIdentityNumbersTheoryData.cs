using System;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests.TestData;

public class InvalidPersonalIdentityNumbersTheoryData : TheoryData<string, PersonIdentifierKind, DateOnly?, PersonIdentifierGender?>
{
    public InvalidPersonalIdentityNumbersTheoryData()
    {
        Add("191202311211", PersonIdentifierKind.PersonalIdentityNumber, null, null); // Invalid month/day combination
        Add("191212121210", PersonIdentifierKind.PersonalIdentityNumber, null, null); // Invalid checkdigit
    }
}
