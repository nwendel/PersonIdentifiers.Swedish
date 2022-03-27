using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PersonIdentifiers.Swedish.EntityFrameworkCore;

public class PersonIdentifierValueConverter : ValueConverter<PersonIdentifier, string>
{
    public PersonIdentifierValueConverter()
        : base(i => i.ToString(), s => PersonIdentifier.Parse(s))
    {
    }
}
