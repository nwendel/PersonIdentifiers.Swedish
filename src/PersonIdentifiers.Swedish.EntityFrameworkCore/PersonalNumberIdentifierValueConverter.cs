using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PersonIdentifiers.Swedish.EntityFrameworkCore;

public class PersonalNumberIdentifierValueConverter : ValueConverter<PersonalNumberIdentifier, string>
{
    public PersonalNumberIdentifierValueConverter()
        : base(i => i.Value, s => PersonalNumberIdentifier.Parse(s))
    {
    }
}
