using System.Diagnostics.CodeAnalysis;
using NodaTime;

namespace PersonIdentifiers.Swedish.Internal;

public static class LocalDateHelper
{
    private static readonly CalendarSystem _calendar = CalendarSystem.Iso;
    private static readonly int _minYear = _calendar.MinYear;
    private static readonly int _maxYear = _calendar.MaxYear;

    // TODO: Standard method in NodaTime?
    //       Or extension method?
    public static bool IsValidDate(int year, int month, int day, [NotNullWhen(true)] out LocalDate? dateOfBirth)
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

        var daysInMonth = CalendarSystem.Iso.GetDaysInMonth(year, month);
        if (day < 1 || day > daysInMonth)
        {
            return false;
        }

        dateOfBirth = new(year, month, day);
        return true;
    }
}
