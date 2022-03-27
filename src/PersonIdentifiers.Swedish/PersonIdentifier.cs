using System.Diagnostics.CodeAnalysis;
using NodaTime;
using PersonIdentifiers.Swedish.Internal;

namespace PersonIdentifiers.Swedish;

public abstract class PersonIdentifier
{
    private readonly string _value;

    protected PersonIdentifier(string value, PersonIdentifierParts parts)
    {
        _value = value;
        Parts = parts;
    }

    public abstract PersonIdentifierKind Kind { get; }

    public abstract string Oid { get; }

    public PersonIdentifierParts Parts { get; }

    public LocalDate? DateOfBirth { get; protected set; }

    public PersonIdentifierGender? Gender { get; protected set; }

    public static PersonIdentifier Parse(string value)
    {
        if (TryParse(value, out var identifier))
        {
            return identifier;
        }

        throw new PersonIdentifierFormatException();
    }

    public static bool TryParse(string value, [NotNullWhen(true)] out PersonIdentifier? identifier)
    {
        if (PersonalNumberIdentifier.TryParse(value, out var personalNumberIdentifier))
        {
            identifier = personalNumberIdentifier;
            return true;
        }

        if (CoordinationNumberIdentifier.TryParse(value, out var coordinationNumberIdentifier))
        {
            identifier = coordinationNumberIdentifier;
            return true;
        }

        if (NationalReserveNumberIdentifier.TryParse(value, out var nationalReserveNumberIdentifier))
        {
            identifier = nationalReserveNumberIdentifier;
            return true;
        }

        identifier = null;
        return false;
    }

    public override string ToString()
    {
        // TODO: This is wrong
        return _value;
    }
}
