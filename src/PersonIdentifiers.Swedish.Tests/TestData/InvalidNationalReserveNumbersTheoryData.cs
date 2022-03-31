using NodaTime;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests.TestData;

public class InvalidNationalReserveNumbersTheoryData : TheoryData<string, PersonIdentifierKind, LocalDate?, PersonIdentifierGender?>
{
    public InvalidNationalReserveNumbersTheoryData()
    {
        Add("19790914AA05", PersonIdentifierKind.NationalReserveNumber, default, default); /* Invalid century */
        Add("23790914AA09", PersonIdentifierKind.NationalReserveNumber, default, default); /* Invalid century */
        Add("00790914AA06", PersonIdentifierKind.NationalReserveNumber, default, default); /* Invalid month (unkown date of birth) */
        Add("00792039AA05", PersonIdentifierKind.NationalReserveNumber, default, default); /* Invalid day (unkown date of birth) */
        Add("00792060AA04", PersonIdentifierKind.NationalReserveNumber, default, default); /* Invalid day (unkown date of birth) */
        Add("22790231AA06", PersonIdentifierKind.NationalReserveNumber, default, default); /* Invalid date */
        Add("00749852APA5", PersonIdentifierKind.NationalReserveNumber, default, default); /* Blacklisted */
    }
}
