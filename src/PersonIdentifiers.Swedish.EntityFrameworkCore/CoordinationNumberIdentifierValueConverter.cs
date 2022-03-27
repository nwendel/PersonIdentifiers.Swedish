using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PersonIdentifiers.Swedish.EntityFrameworkCore;

public class CoordinationNumberIdentifierValueConverter : ValueConverter<CoordinationNumberIdentifier, string>
{
    public CoordinationNumberIdentifierValueConverter()
        : base(i => i.Value, s => CoordinationNumberIdentifier.Parse(s))
    {
    }
}
