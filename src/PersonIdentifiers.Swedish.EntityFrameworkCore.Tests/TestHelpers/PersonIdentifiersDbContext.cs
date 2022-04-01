using System;
using Microsoft.EntityFrameworkCore;
using PersonIdentifiers.Swedish.EntityFrameworkCore.Tests.Entities;

namespace PersonIdentifiers.Swedish.EntityFrameworkCore.Tests.TestHelpers;

public class PersonIdentifiersDbContext : DbContext
{
    private readonly string _databaseName;

    public PersonIdentifiersDbContext(Guid databaseName)
    {
        _databaseName = databaseName.ToString();
    }

    public DbSet<PersonIdentifierEntity> PersonIdentifiers => Set<PersonIdentifierEntity>();

    public DbSet<PersonalIdentityNumberEntity> PersonalNumberIdentifiers => Set<PersonalIdentityNumberEntity>();

    public DbSet<CoordinationNumberEntity> CoordinationNumberIdentifiers => Set<CoordinationNumberEntity>();

    public DbSet<NationalReserveNumberEntity> NationalReserveNumberIdentifiers => Set<NationalReserveNumberEntity>();

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.AddPersonIdentifiersConventions();

        base.ConfigureConventions(configurationBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(_databaseName);

        base.OnConfiguring(optionsBuilder);
    }
}
