using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using PersonIdentifiers.Swedish.Internal;
using PersonIdentifiers.Swedish.Tests.Conventions.TestHelpers.Internal;

namespace PersonIdentifiers.Swedish.Tests.Conventions.TestHelpers;

public abstract class Convention
{
    private ConventionContext? _context;

    // TODO: Should setter be public? Maybe only settable via en interface?
    public ConventionContext Context
    {
        get
        {
            if (_context == null)
            {
                throw new InvalidOperationException("Context not initalized");
            }

            return _context;
        }
        set => _context = value;
    }

    [DoesNotReturn]
    protected void Fail(Type type, string message)
    {
        GuardAgainst.Null(type);
        GuardAgainst.NullOrWhiteSpace(message);

        Context.Add($"Type {type.Name} {message}");
        throw new ConventionFailedException();
    }

    [DoesNotReturn]
    protected void Fail(Type type, MethodInfo method, string message)
    {
        GuardAgainst.Null(type);
        GuardAgainst.Null(method);
        GuardAgainst.NullOrWhiteSpace(message);

        Context.Add($"Type {type.Name} method {method.Name} {message}");
        throw new ConventionFailedException();
    }
}
