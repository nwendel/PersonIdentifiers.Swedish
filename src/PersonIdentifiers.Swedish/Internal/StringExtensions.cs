namespace PersonIdentifiers.Swedish.Internal;

public static class StringExtensions
{
    public static bool IsNumeric(this string self)
    {
        GuardAgainst.Null(self);

        return self.All(char.IsNumber);
    }
}
