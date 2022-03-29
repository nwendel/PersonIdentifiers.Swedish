using Xunit;

namespace PersonIdentifiers.Swedish.Tests
{
    public class PersonIdentifierTests
    {
        [Fact]
        public void CanToString()
        {
            var pnr = "191212121212";
            var identifier = PersonIdentifier.Parse(pnr);

            Assert.Equal(pnr, identifier.ToString());
        }
    }
}
