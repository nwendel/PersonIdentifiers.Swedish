using NodaTime;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests.TestData;

public class InvalidPersonalNumberIdentifiersTheoryData : TheoryData<string, PersonIdentifierKind, LocalDate?, PersonIdentifierGender?>
{
    public InvalidPersonalNumberIdentifiersTheoryData()
    {
        Add("191202311211", PersonIdentifierKind.PersonalNumber, null, null);
    }
}
