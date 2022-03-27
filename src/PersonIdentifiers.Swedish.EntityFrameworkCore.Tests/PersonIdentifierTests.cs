using System.Linq;
using PersonIdentifiers.Swedish.EntityFrameworkCore.Tests.Entities;
using Xunit;

namespace PersonIdentifiers.Swedish.EntityFrameworkCore.Tests
{
    public class PersonIdentifierTests
    {
        private PersonIdentifiersDbContext _dbContext;
        private PersonIdentifiersDbContext _dbContext2;

        public PersonIdentifierTests()
        {
            _dbContext = new PersonIdentifiersDbContext();
            _dbContext2 = new PersonIdentifiersDbContext();
        }

        [Fact]
        public void Asdf()
        {
            _ = PersonIdentifier.TryParse("191212121212", out var identifier);
            var asdf = new PersonIdentifierEntity
            {
                PersonIdentifier = identifier,
            };

            _dbContext.Add(asdf);
            _dbContext.SaveChanges();

            var qwerty = _dbContext2.PersonIdentifiers.Single();
        }
    }
}
