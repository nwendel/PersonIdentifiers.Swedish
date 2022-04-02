using System;
using PersonIdentifiers.Swedish.Internal;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests.Internal
{
    public class UnreachableCodeExceptionTests
    {
        [Fact]
        public void CanCreateWithMessage()
        {
            var ex = new UnreachableCodeException("the-message");
            Assert.Equal("the-message", ex.Message);
        }

        [Fact]
        public void ThrowsOnCreateNullMessage()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new UnreachableCodeException(null!));
            Assert.Equal("message", ex.ParamName);
        }
    }
}
