using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PersonIdentifiers.Swedish.EntityFrameworkCore;

public class PersonIdentifierValueConverter : ValueConverter<PersonIdentifier, string>
{
    private static Expression<Func<PersonIdentifier, string>> _convertToProviderExpression = null!;

    private static Expression<Func<string, PersonIdentifier>> _convertFromProviderExpression = null!;

    public PersonIdentifierValueConverter()
        : base(_convertToProviderExpression, _convertFromProviderExpression)
    {
    }
}
