using NodaTime;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests.TestData;

public class PersonalNumberIdentifiersTheoryData : TheoryData<string, PersonIdentifierKind, LocalDate?, PersonIdentifierGender?>
{
    public PersonalNumberIdentifiersTheoryData()
    {
        Add("191212121212", PersonIdentifierKind.PersonalNumber, new LocalDate(1912, 12, 12), PersonIdentifierGender.Male);
        Add("200101010106", PersonIdentifierKind.PersonalNumber, new LocalDate(2001, 1, 1), PersonIdentifierGender.Female);
    }
}
