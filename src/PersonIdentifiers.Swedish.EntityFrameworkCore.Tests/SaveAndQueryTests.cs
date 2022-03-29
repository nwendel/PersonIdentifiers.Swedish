using System;
using System.Linq;
using PersonIdentifiers.Swedish.EntityFrameworkCore.Tests.Entities;
using PersonIdentifiers.Swedish.EntityFrameworkCore.Tests.TestHelpers;
using Xunit;

namespace PersonIdentifiers.Swedish.EntityFrameworkCore.Tests;

public class SaveAndQueryTests
{
    private const string _personalNumber = "191212121212";
    private const string _coordinationNumber = "197010632391";
    private const string _nationalReserveNumber = "22790814AA01";
    private readonly Guid _databaseName = Guid.NewGuid();

    [Fact]
    public void CanPersonIdentifier()
    {
        var identifier = PersonIdentifier.Parse(_personalNumber);
        var entity = new PersonIdentifierEntity(identifier);

        using var dbContext = new PersonIdentifiersDbContext(_databaseName);
        dbContext.Add(entity);
        dbContext.SaveChanges();

        using var dbContext2 = new PersonIdentifiersDbContext(_databaseName);
        var result = dbContext2.PersonIdentifiers.Single();

        Assert.Equal(_personalNumber, result.Identifier.Value);
    }

    [Fact]
    public void CanPersonalNumberIdentifier()
    {
        var identifier = PersonalNumberIdentifier.Parse(_personalNumber);
        var entity = new PersonalNumberIdentifierEntity(identifier);

        using var dbContext = new PersonIdentifiersDbContext(_databaseName);
        dbContext.Add(entity);
        dbContext.SaveChanges();

        using var dbContext2 = new PersonIdentifiersDbContext(_databaseName);
        var result = dbContext2.PersonalNumberIdentifiers.Single();

        Assert.Equal(_personalNumber, result.Identifier.Value);
    }

    [Fact]
    public void CanCoordinationNumberIdentifier()
    {
        var identifier = CoordinationNumberIdentifier.Parse(_coordinationNumber);
        var entity = new CoordinationNumberIdentifierEntity(identifier);

        using var dbContext = new PersonIdentifiersDbContext(_databaseName);
        dbContext.Add(entity);
        dbContext.SaveChanges();

        using var dbContext2 = new PersonIdentifiersDbContext(_databaseName);
        var result = dbContext2.CoordinationNumberIdentifiers.Single();

        Assert.Equal(_coordinationNumber, result.Identifier.Value);
    }

    [Fact]
    public void CanNationalReserveNumberIdentifier()
    {
        var identifier = NationalReserveNumberIdentifier.Parse(_nationalReserveNumber);
        var entity = new NationalReserveNumberIdentifierEntity(identifier);

        using var dbContext = new PersonIdentifiersDbContext(_databaseName);
        dbContext.Add(entity);
        dbContext.SaveChanges();

        using var dbContext2 = new PersonIdentifiersDbContext(_databaseName);
        var result = dbContext2.NationalReserveNumberIdentifiers.Single();

        Assert.Equal(_nationalReserveNumber, result.Identifier.Value);
    }
}
