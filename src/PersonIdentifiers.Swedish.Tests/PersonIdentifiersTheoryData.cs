using NodaTime;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests;

public class PersonIdentifiersTheoryData : TheoryData<string, PersonIdentifierKind, LocalDate?, PersonIdentifierGender?>
{
    public PersonIdentifiersTheoryData()
    {
        Add("191212121212", PersonIdentifierKind.PersonalNumber, new LocalDate(1912, 12, 12), PersonIdentifierGender.Male);
        Add("200101010106", PersonIdentifierKind.PersonalNumber, new LocalDate(2001, 1, 1), PersonIdentifierGender.Female);
        Add("22790814AA01", PersonIdentifierKind.NationalReserveNumber, new LocalDate(1979, 8, 14), PersonIdentifierGender.Female);
        Add("22950606FH20", PersonIdentifierKind.NationalReserveNumber, new LocalDate(1995, 6, 6), PersonIdentifierGender.Female);
        Add("25780404KHD5", PersonIdentifierKind.NationalReserveNumber, new LocalDate(1978, 4, 4), default);
        Add("00342145BZ31", PersonIdentifierKind.NationalReserveNumber, default, PersonIdentifierGender.Male);
        Add("00749852BZK0", PersonIdentifierKind.NationalReserveNumber, default, default);
        Add("197010632391", PersonIdentifierKind.CoordinationNumber, new LocalDate(1970, 10, 3), PersonIdentifierGender.Male);
        Add("197010632383", PersonIdentifierKind.CoordinationNumber, new LocalDate(1970, 10, 3), PersonIdentifierGender.Female);
    }
}
