using System;
using System.Collections.Generic;
using System.Linq;
using PersonIdentifiers.Swedish.Internal;
using PersonIdentifiers.Swedish.Tests.Conventions.TestHelpers.Internal;

namespace PersonIdentifiers.Swedish.Tests.Conventions.TestHelpers;

public static class ConventionAssert
{
    public static void TypesFollow<T>(IEnumerable<Type> types)
        where T : TypeConvention, new()
    {
        GuardAgainst.Null(types);

        var context = new ConventionContext();
        var convention = new T();
        convention.Context = context;

        foreach (var type in types)
        {
            try
            {
                convention.Assert(type);
            }
            catch (ConventionFailedException)
            {
                continue;
            }
        }

        var messages = convention.Context.Messages;
        if (messages.Any())
        {
            var message = string.Join(Environment.NewLine, messages);
            throw new ConventionException(message);
        }
    }
}
