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

        self.Properties<PersonalIdentityNumber>()
            .HaveMaxLength(12)
            .HaveConversion<PersonalIdentityNumberValueConverter>();

        self.Properties<CoordinationNumber>()
            .HaveMaxLength(12)
            .HaveConversion<CoordinationNumberValueConverter>();

        self.Properties<NationalReserveNumber>()
            .HaveMaxLength(12)
            .HaveConversion<NationalReserveNumberValueConverter>();
    }
}
