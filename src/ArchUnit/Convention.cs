using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using ArchUnit.Infrastructure;
using ArchUnit.Internal;

namespace ArchUnit;

public abstract class Convention : IInitializeConvention
{
    private ConventionContext? _context;

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
    }

    void IInitializeConvention.Initialize(ConventionContext context)
    {
        GuardAgainst.Null(context);

        _context = context;
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
