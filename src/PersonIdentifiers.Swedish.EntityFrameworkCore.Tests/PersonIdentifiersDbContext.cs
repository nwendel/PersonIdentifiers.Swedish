using Microsoft.EntityFrameworkCore;
using PersonIdentifiers.Swedish.EntityFrameworkCore.Tests.Entities;

namespace PersonIdentifiers.Swedish.EntityFrameworkCore.Tests;

public class PersonIdentifiersDbContext : DbContext
{
    public DbSet<PersonIdentifierEntity> PersonIdentifiers => Set<PersonIdentifierEntity>();

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.AddPersonIdentifiersConventions();

        base.ConfigureConventions(configurationBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("asdf");

        base.OnConfiguring(optionsBuilder);
    }
}
