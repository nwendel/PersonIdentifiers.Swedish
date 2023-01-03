using PersonIdentifiers.Swedish.Internal;

namespace PersonIdentifiers.Swedish;

public class PersonIdentifierFormatException : FormatException
{
    public PersonIdentifierFormatException(Type personIdentifierType)
        : base($"Invalid {personIdentifierType?.Name} format")
    {
        GuardAgainst.Null(personIdentifierType);

        PersonIdentifierType = personIdentifierType;
    }

    public Type PersonIdentifierType { get; }
}
