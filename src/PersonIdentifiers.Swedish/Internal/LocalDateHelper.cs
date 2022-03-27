using NodaTime;

namespace PersonIdentifiers.Swedish.Internal
{
    public static class LocalDateHelper
    {
        // TODO: Standard method in NodaTime?
        public static bool IsInvalidDate(int year, int month, int day)
        {
            // TODO: Rewrite without try/catch
            try
            {
                _ = new LocalDate(year, month, day);
            }
            catch (ArgumentOutOfRangeException)
            {
                return true;
            }

            return false;
        }
    }
}
