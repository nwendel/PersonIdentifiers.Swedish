using PersonIdentifiers.Swedish.Internal;

namespace PersonIdentifiers.Swedish;

public class PersonIdentifierFormatException : FormatException
{
    public PersonIdentifierFormatException(Type personIdentifierType)
        : base($"Invalid {personIdentifierType?.Name} format")
    {
        GuardAgainst.Null(personIdentifierType);
        GuardAgainst.Condition(
            !personIdentifierType.IsAssignableTo(typeof(PersonIdentifier)),
            $"{personIdentifierType.FullName} is not assignable to {typeof(PersonIdentifier).FullName}",
            nameof(personIdentifierType));

        PersonIdentifierType = personIdentifierType;
    }

    public Type PersonIdentifierType { get; }
}
