using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PersonIdentifiers.Swedish.EntityFrameworkCore;

public class NationalReserveNumberValueConverter : ValueConverter<NationalReserveNumber, string>
{
    public NationalReserveNumberValueConverter()
        : base(i => i.Value, s => NationalReserveNumber.Parse(s))
    {
    }
}
