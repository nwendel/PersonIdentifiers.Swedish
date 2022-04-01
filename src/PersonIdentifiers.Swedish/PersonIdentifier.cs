using System.Diagnostics.CodeAnalysis;
using NodaTime;
using PersonIdentifiers.Swedish.Internal;
using PersonIdentifiers.Swedish.Local;
using PersonIdentifiers.Swedish.Options;

namespace PersonIdentifiers.Swedish;

public abstract class PersonIdentifier : IPersonIdentifierPartsAware<PersonIdentifierParts>
{
    private readonly string _value;

    protected PersonIdentifier(string value, PersonIdentifierParts parts)
    {
        GuardAgainst.NullOrWhiteSpace(value);
        GuardAgainst.Null(parts);

        _value = value;
        Parts = parts;
    }

    public abstract PersonIdentifierKind Kind { get; }

    public abstract string Oid { get; }

    public virtual PersonIdentifierParts Parts { get; }

    [MemberNotNullWhen(true, nameof(DateOfBirth))]
    public bool IsDateOfBirthKnown => DateOfBirth.HasValue;

    public LocalDate? DateOfBirth { get; protected set; }

    [MemberNotNullWhen(true, nameof(Gender))]
    public bool IsGenderKnown => Gender.HasValue;

    public PersonIdentifierGender? Gender { get; protected set; }

    public string Value => _value;

    public static PersonIdentifier Parse(string value) =>
        TryParse(value, out var identifier)
            ? identifier
            : throw new PersonIdentifierFormatException();

    public static PersonIdentifier Parse(string value, PersonIdentifierParseOptions options) =>
        TryParse(value, options, out var identifier)
            ? identifier
            : throw new PersonIdentifierFormatException();

    public static bool TryParse(string value, [NotNullWhen(true)] out PersonIdentifier? identifier) =>
        TryParse(value, PersonIdentifierParseOptions.Default, out identifier);

    public static bool TryParse(string value, PersonIdentifierParseOptions options, [NotNullWhen(true)] out PersonIdentifier? identifier)
    {
        GuardAgainst.Null(value);
        GuardAgainst.Null(options);

        if (PersonalIdentityNumber.TryParse(value, out var personalIdentityNumber))
        {
            identifier = personalIdentityNumber;
            return true;
        }

        if (CoordinationNumber.TryParse(value, out var coordinationNumber))
        {
            identifier = coordinationNumber;
            return true;
        }

        if (NationalReserveNumber.TryParse(value, out var nationalReserveNumber))
        {
            identifier = nationalReserveNumber;
            return true;
        }

        if (options.AllowLocal && LocalReserveNumber.TryParse(value, options, out var localReserveNumber))
        {
            identifier = localReserveNumber;
            return true;
        }

        identifier = null;
        return false;
    }

    public override string ToString()
    {
        return _value;
    }
}
