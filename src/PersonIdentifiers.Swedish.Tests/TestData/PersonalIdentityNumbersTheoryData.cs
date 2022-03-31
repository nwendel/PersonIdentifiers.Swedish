using NodaTime;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests.TestData;

public class PersonalIdentityNumbersTheoryData : TheoryData<string, PersonIdentifierKind, LocalDate?, PersonIdentifierGender?>
{
    public PersonalIdentityNumbersTheoryData()
    {
        Add("191212121212", PersonIdentifierKind.PersonalIdentityNumber, new LocalDate(1912, 12, 12), PersonIdentifierGender.Male);
        Add("200101010106", PersonIdentifierKind.PersonalIdentityNumber, new LocalDate(2001, 1, 1), PersonIdentifierGender.Female);
    }
}
