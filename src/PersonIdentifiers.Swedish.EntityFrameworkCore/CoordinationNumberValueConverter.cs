using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PersonIdentifiers.Swedish.EntityFrameworkCore;

public class CoordinationNumberValueConverter : ValueConverter<CoordinationNumber, string>
{
    public CoordinationNumberValueConverter()
        : base(i => i.Value, s => CoordinationNumber.Parse(s))
    {
    }
}
