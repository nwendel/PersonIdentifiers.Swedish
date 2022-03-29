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

    public DbSet<PersonalNumberIdentifierEntity> PersonalNumberIdentifiers => Set<PersonalNumberIdentifierEntity>();

    public DbSet<CoordinationNumberIdentifierEntity> CoordinationNumberIdentifiers => Set<CoordinationNumberIdentifierEntity>();

    public DbSet<NationalReserveNumberIdentifierEntity> NationalReserveNumberIdentifiers => Set<NationalReserveNumberIdentifierEntity>();

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
