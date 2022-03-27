using Microsoft.EntityFrameworkCore;
using PersonIdentifiers.Swedish.Internal;

namespace PersonIdentifiers.Swedish.EntityFrameworkCore;

public static class ModelConfigurationBuilderExtensions
{
    public static void AddPersonIdentifiersConventions(this ModelConfigurationBuilder self)
    {
        GuardAgainst.Null(self);

        self.Properties<PersonIdentifier>()
            .HaveMaxLength(12)
            .HaveConversion<PersonIdentifierValueConverter>();

        self.Properties<PersonalNumberIdentifier>()
            .HaveMaxLength(12)
            .HaveConversion<PersonalNumberIdentifierValueConverter>();

        self.Properties<CoordinationNumberIdentifier>()
            .HaveMaxLength(12)
            .HaveConversion<CoordinationNumberIdentifierValueConverter>();

        self.Properties<NationalReserveNumberIdentifier>()
            .HaveMaxLength(12)
            .HaveConversion<NationalReserveNumberIdentifierValueConverter>();
    }
}
