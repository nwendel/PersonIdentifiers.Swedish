using PersonIdentifiers.Swedish.Internal;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests.Internal
{
    public class DateOnlyHelperTests
    {
        [Fact]
        public void CanTryParseFalseWrongYear()
        {
            Assert.False(DateOnlyHelper.TryParse(-1, 1, 1, out var _));
        }

        [Fact]
        public void CanTryParseFalseWrongMonth()
        {
            Assert.False(DateOnlyHelper.TryParse(2022, 0, 1, out var _));
        }

        [Fact]
        public void CanTryParseFalseWrongDay()
        {
            Assert.False(DateOnlyHelper.TryParse(2022, 1, 0, out var _));
        }
    }
}
