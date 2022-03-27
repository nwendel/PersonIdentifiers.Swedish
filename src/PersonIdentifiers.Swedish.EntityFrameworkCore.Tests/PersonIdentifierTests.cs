using PersonIdentifiers.Swedish.EntityFrameworkCore.Tests.Entities;
using Xunit;

namespace PersonIdentifiers.Swedish.EntityFrameworkCore.Tests
{
    public class PersonIdentifierTests
    {
        private PersonIdentifiersDbContext _dbContext;

        public PersonIdentifierTests()
        {
            _dbContext = new PersonIdentifiersDbContext();
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
        }
    }
}
