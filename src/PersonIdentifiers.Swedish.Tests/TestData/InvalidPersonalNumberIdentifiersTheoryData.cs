using NodaTime;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests.TestData;

public class InvalidPersonalNumberIdentifiersTheoryData : TheoryData<string, PersonIdentifierKind, LocalDate?, PersonIdentifierGender?>
{
    public InvalidPersonalNumberIdentifiersTheoryData()
    {
        Add("191202311211", PersonIdentifierKind.PersonalNumber, null, null); // Invalid month/day combination
        Add("191212121210", PersonIdentifierKind.PersonalNumber, null, null); // Invalid checkdigit
    }
}
