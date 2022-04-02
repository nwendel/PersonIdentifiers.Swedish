namespace PersonIdentifiers.Swedish.Internal;

public class UnreachableCodeException : InvalidOperationException
{
    public UnreachableCodeException(string message)
        : base(message)
    {
        GuardAgainst.Null(message);
    }
}
