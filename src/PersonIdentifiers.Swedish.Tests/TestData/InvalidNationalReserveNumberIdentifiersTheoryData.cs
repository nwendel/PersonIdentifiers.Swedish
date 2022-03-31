using NodaTime;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests.TestData;

public class InvalidNationalReserveNumberIdentifiersTheoryData : TheoryData<string, PersonIdentifierKind, LocalDate?, PersonIdentifierGender?>
{
    public InvalidNationalReserveNumberIdentifiersTheoryData()
    {
        Add("22790814AA01", PersonIdentifierKind.NationalReserveNumber, new LocalDate(1979, 8, 14), PersonIdentifierGender.Female);
        Add("22950606FH12", PersonIdentifierKind.NationalReserveNumber, new LocalDate(1995, 6, 6), PersonIdentifierGender.Male);
        Add("25780404KHD5", PersonIdentifierKind.NationalReserveNumber, new LocalDate(1978, 4, 4), default);
        Add("00342145BZ31", PersonIdentifierKind.NationalReserveNumber, default, PersonIdentifierGender.Male);
        Add("00749852BZK0", PersonIdentifierKind.NationalReserveNumber, default, default);
    }
}
