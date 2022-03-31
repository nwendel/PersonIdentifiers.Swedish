using System.Diagnostics.CodeAnalysis;
using NodaTime;

namespace PersonIdentifiers.Swedish.Internal
{
    public static class LocalDateHelper
    {
        // TODO: Standard method in NodaTime?
        public static bool IsValidDate(int year, int month, int day, [NotNullWhen(true)] out LocalDate? dateOfBirth)
        {
            // TODO: Rewrite without try/catch
            try
            {
                dateOfBirth = new LocalDate(year, month, day);
                return true;
            }
            catch (ArgumentOutOfRangeException)
            {
                dateOfBirth = default;
                return false;
            }
        }
    }
}
