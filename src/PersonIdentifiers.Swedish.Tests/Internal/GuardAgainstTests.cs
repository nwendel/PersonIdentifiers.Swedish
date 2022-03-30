using System;
using PersonIdentifiers.Swedish.Internal;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests.Internal;

public class GuardAgainstTests
{
    [Fact]
    public void ThrowsOnCondition()
    {
        var ex = Assert.Throws<ArgumentException>(() => GuardAgainst.Condition(true, "message", "argument"));
        Assert.StartsWith("message", ex.Message, StringComparison.Ordinal);
        Assert.Equal("argument", ex.ParamName);
    }

    [Fact]
    public void ThrowsOnNull()
    {
        var ex = Assert.Throws<ArgumentNullException>(() => Method(null));
        Assert.Equal("value", ex.ParamName);

        static void Method(object? value)
        {
            GuardAgainst.Null(value);
        }
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void ThrowsOnNullOrWhiteSpace(string? value)
    {
        var ex = Assert.Throws<ArgumentNullException>(() => GuardAgainst.NullOrWhiteSpace(value));
        Assert.Equal(nameof(value), ex.ParamName);
    }

    [Fact]
    public void ThrowsOnUndefined()
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => Method((PersonIdentifierKind)int.MinValue));
        Assert.Equal("value", ex.ParamName);

        static void Method(PersonIdentifierKind value)
        {
            GuardAgainst.Undefined(value);
        }
    }
}
