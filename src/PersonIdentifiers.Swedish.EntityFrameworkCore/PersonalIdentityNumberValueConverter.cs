using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PersonIdentifiers.Swedish.EntityFrameworkCore;

public class PersonalIdentityNumberValueConverter : ValueConverter<PersonalIdentityNumber, string>
{
    public PersonalIdentityNumberValueConverter()
        : base(i => i.Value, s => PersonalIdentityNumber.Parse(s))
    {
    }
}
