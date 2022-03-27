using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PersonIdentifiers.Swedish.EntityFrameworkCore;

public class NationalReserveNumberIdentifierValueConverter : ValueConverter<NationalReserveNumberIdentifier, string>
{
    public NationalReserveNumberIdentifierValueConverter()
        : base(i => i.Value, s => NationalReserveNumberIdentifier.Parse(s))
    {
    }
}
