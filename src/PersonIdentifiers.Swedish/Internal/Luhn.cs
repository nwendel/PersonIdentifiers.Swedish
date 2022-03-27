using System.Globalization;

namespace PersonIdentifiers.Swedish.Internal
{
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

                /*
                var digit = value[value.Length - 1 - ix] - '0';
                digit = ix.IsOdd() ? digit * 2 : digit;
                if (digit > 9)
                {
                    digit -= 9;
                }

                sum += digit;
                */
            }

            return sum % 10 == 0;
        }
    }
}
