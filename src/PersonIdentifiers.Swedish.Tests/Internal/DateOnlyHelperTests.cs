using PersonIdentifiers.Swedish.Internal;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests.Internal
{
    public class DateOnlyHelperTests
    {
        [Fact]
        public void CanIsValidFalseWrongYear()
        {
            Assert.False(DateOnlyHelper.IsValidDate(-1, 1, 1, out var _));
        }

        [Fact]
        public void CanIsValidFalseWrongMonth()
        {
            Assert.False(DateOnlyHelper.IsValidDate(2022, 0, 1, out var _));
        }

        [Fact]
        public void CanIsValidFalseWrongDay()
        {
            Assert.False(DateOnlyHelper.IsValidDate(2022, 1, 0, out var _));
        }
    }
}
