using System;
using System.Linq;
using System.Linq.Expressions;
using PersonIdentifiers.Swedish.Internal;

namespace PersonIdentifiers.Swedish.Tests.TestHelpers;

public static class ObjectExtensions
{
    public static void Set<T, TValue>(this T self, Expression<Func<T, TValue>> propertyExpression, TValue value)
    {
        GuardAgainst.Null(propertyExpression);

        if (propertyExpression == null)
        {
            throw new ArgumentNullException(nameof(propertyExpression));
        }

        if (propertyExpression.Body is ParameterExpression)
        {
            throw new ArgumentException("Not a valid property expression", nameof(propertyExpression));
        }

        if (propertyExpression.Body is not MemberExpression memberExpression)
        {
            if (propertyExpression.Body is not UnaryExpression unaryExpression)
            {
                throw new ArgumentException("Not a valid property expression", nameof(propertyExpression));
            }

            if (unaryExpression.Operand is not MemberExpression memberExpression2)
            {
                throw new ArgumentException("Not a valid property expression", nameof(propertyExpression));
            }

            memberExpression = memberExpression2;
        }

        var propertyName = memberExpression.Member.Name;
        var property = typeof(T).GetProperties()
            .First(x => x.Name == propertyName && x.CanWrite);
        if (property == null)
        {
            throw new ArgumentException($"Property {propertyName} has no setter", nameof(propertyExpression));
        }

        property.SetValue(self, value);
    }
}
