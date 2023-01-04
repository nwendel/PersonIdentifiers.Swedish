using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace PersonIdentifiers.Swedish.Internal;

public static class DateOnlyHelper
{
    private static readonly GregorianCalendar _calendar = new();
    private static readonly int _minYear = _calendar.MinSupportedDateTime.Year;
    private static readonly int _maxYear = _calendar.MaxSupportedDateTime.Year;

    public static bool TryParse(int year, int month, int day, [NotNullWhen(true)] out DateOnly? date)
    {
        date = default;

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

        date = new(year, month, day);
        return true;
    }
}
