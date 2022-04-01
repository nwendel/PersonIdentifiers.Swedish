using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace PersonIdentifiers.Swedish.Internal;

public static class LocalDateHelper
{
    private static readonly GregorianCalendar _calendar = new();
    private static readonly int _minYear = _calendar.MinSupportedDateTime.Year;
    private static readonly int _maxYear = _calendar.MaxSupportedDateTime.Year;

    // TODO: Standard method in Bcl?
    public static bool IsValidDate(int year, int month, int day, [NotNullWhen(true)] out DateOnly? dateOfBirth)
    {
        dateOfBirth = default;

        if (year < _minYear || year > _maxYear)
        {
            return false;
        }

        var monthsInYear = _calendar.GetMonthsInYear(year);
        if (month < 1 || month > monthsInYear)
        {
            return false;
        }

        var daysInMonth = _calendar.GetDaysInMonth(year, month);
        if (day < 1 || day > daysInMonth)
        {
            return false;
        }

        dateOfBirth = new(year, month, day);
        return true;
    }
}
