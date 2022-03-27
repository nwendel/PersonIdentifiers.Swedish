using System;
using System.Linq;
using PersonIdentifiers.Swedish.EntityFrameworkCore.Tests.Entities;
using PersonIdentifiers.Swedish.EntityFrameworkCore.Tests.TestHelpers;
using Xunit;

namespace PersonIdentifiers.Swedish.EntityFrameworkCore.Tests
{
    public class PersonIdentifierTests
    {
        private const string _pnr = "191212121212";
        private readonly Guid _databaseName = Guid.NewGuid();

        [Fact]
        public void Asdf()
        {
            var identifier = PersonIdentifier.Parse(_pnr);
            var entity = new PersonIdentifierEntity(identifier);

            using var dbContext = new PersonIdentifiersDbContext(_databaseName);
            dbContext.Add(entity);
            dbContext.SaveChanges();

            using var dbContext2 = new PersonIdentifiersDbContext(_databaseName);
            var result = dbContext2.PersonIdentifiers.Single();

            Assert.Equal(_pnr, result.Identifier.Value);
        }
    }
}
