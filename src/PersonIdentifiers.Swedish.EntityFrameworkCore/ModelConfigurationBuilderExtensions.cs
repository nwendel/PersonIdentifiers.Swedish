using Microsoft.EntityFrameworkCore;

namespace PersonIdentifiers.Swedish.EntityFrameworkCore;

public static class ModelConfigurationBuilderExtensions
{
    public static void AddPersonIdentifiersConventions(this ModelConfigurationBuilder self)
    {
        self.Properties<PersonIdentifier>()
            .HaveConversion<PersonIdentifierValueConverter>();
    }
}
