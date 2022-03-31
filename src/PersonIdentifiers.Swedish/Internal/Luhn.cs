using System.Globalization;

namespace PersonIdentifiers.Swedish.Internal;

public static class Luhn
{
    public static bool IsValid(string value)
    {
        GuardAgainst.Null(value);

        var sum = 0;
        for (var ix = 0; ix < value.Length; ix++)
        {
            var position = value[value.Length - 1 - ix];
            var number = char.IsNumber(position) ? position - '0' : position;
            number = ix.IsOdd() ? number * 2 : number;

            sum += number
                .ToString(CultureInfo.CurrentCulture)
                .Select(x => x - '0')
                .Sum();
        }

        return sum % 10 == 0;
    }

    // TODO: Merge methods to reduce duplication?
    public static int Calculate(string value)
    {
        GuardAgainst.Null(value);

        var sum = 0;
        for (var ix = 0; ix < value.Length; ix++)
        {
            var position = value[value.Length - 1 - ix];
            var number = char.IsNumber(position) ? position - '0' : position;
            number = ix.IsEven() ? number * 2 : number;

            sum += number
                .ToString(CultureInfo.CurrentCulture)
                .Select(x => x - '0')
                .Sum();
        }

        var checkdigit = (10 - (sum % 10)) % 10;
        return checkdigit;
    }
}
