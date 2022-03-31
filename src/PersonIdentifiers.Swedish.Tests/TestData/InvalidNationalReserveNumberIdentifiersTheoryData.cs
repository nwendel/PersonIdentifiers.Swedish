using NodaTime;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests.TestData;

public class InvalidNationalReserveNumberIdentifiersTheoryData : TheoryData<string, PersonIdentifierKind, LocalDate?, PersonIdentifierGender?>
{
    public InvalidNationalReserveNumberIdentifiersTheoryData()
    {
        Add("19790914AA05", PersonIdentifierKind.NationalReserveNumber, null, null); /* Invalid century */
        Add("23790914AA09", PersonIdentifierKind.NationalReserveNumber, null, null); /* Invalid century */
        Add("00790914AA06", PersonIdentifierKind.NationalReserveNumber, null, null); /* Invalid month (unkown date of birth) */
        Add("00792039AA05", PersonIdentifierKind.NationalReserveNumber, null, null); /* Invalid day (unkown date of birth) */
        Add("00792060AA04", PersonIdentifierKind.NationalReserveNumber, null, null); /* Invalid day (unkown date of birth) */
        Add("22790231AA06", PersonIdentifierKind.NationalReserveNumber, null, null); /* Invalid date */
    }
}
