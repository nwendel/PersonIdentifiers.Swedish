using Microsoft.EntityFrameworkCore;

namespace PersonIdentifiers.Swedish.EntityFrameworkCore;

public static class ModelConfigurationBuilderExtensions
{
    public static void AddPersonIdentifiersConventions(this ModelConfigurationBuilder self)
    {
        self.Properties<PersonIdentifier>()
            .HaveMaxLength(12)
            .HaveConversion<PersonIdentifierValueConverter>();
    }
}
