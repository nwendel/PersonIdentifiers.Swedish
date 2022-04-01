using System.Globalization;

namespace PersonIdentifiers.Swedish.Internal;

public static class Luhn
{
    public static bool IsValid(string value)
    {
        var sum = Sum(value, x => x.IsOdd());
        return sum % 10 == 0;
    }

    public static int Calculate(string value)
    {
        var sum = Sum(value, x => x.IsEven());
        var checkdigit = (10 - (sum % 10)) % 10;
        return checkdigit;
    }

    private static int Sum(string value, Func<int, bool> doubleNumber)
    {
        GuardAgainst.Null(value);

        var sum = 0;
        for (var ix = 0; ix < value.Length; ix++)
        {
            var position = value[value.Length - 1 - ix];
            var number = char.IsNumber(position)
                ? position - '0'
                : position;
            number = doubleNumber(ix)
                ? number * 2
                : number;

            sum += number
                .ToString(CultureInfo.CurrentCulture)
                .Select(x => x - '0')
                .Sum();
        }

        return sum;
    }
}
