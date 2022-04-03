using System.Diagnostics.CodeAnalysis;
using PersonIdentifiers.Swedish.Internal;
using PersonIdentifiers.Swedish.Local;
using PersonIdentifiers.Swedish.Options;

namespace PersonIdentifiers.Swedish;

public abstract class PersonIdentifier :
    IPersonIdentifierPartsAware<PersonIdentifierParts>,
    IEquatable<PersonIdentifier>
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

    public DateOnly? DateOfBirth { get; protected set; }

    [MemberNotNullWhen(true, nameof(Gender))]
    public bool IsGenderKnown => Gender.HasValue;

    public PersonIdentifierGender? Gender { get; protected set; }

    public string Value => _value;

    public static PersonIdentifier Parse(string value) =>
        Parse(value, PersonIdentifierParseOptions.Default);

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

        var parsers = GetParsers();
        foreach (var parser in parsers)
        {
            identifier = parser();
            if (identifier != null)
            {
                return true;
            }
        }

        identifier = default;
        return false;

        List<Func<PersonIdentifier?>> GetParsers()
        {
            var parsers = new List<Func<PersonIdentifier?>>
            {
                () => PersonalIdentityNumber.TryParse(value, out var personalIdentityNumber) ? personalIdentityNumber : null,
                () => CoordinationNumber.TryParse(value, out var coordinationNumber) ? coordinationNumber : null,
                () => NationalReserveNumber.TryParse(value, out var nationalReserveNumber) ? nationalReserveNumber : null,
            };

            if (options.AllowLocal)
            {
                parsers.Add(() => LocalReserveNumber.TryParse(value, options, out var localReserveNumber) ? localReserveNumber : null);
            }

            return parsers;
        }
    }

    public override bool Equals(object? obj) =>
        obj is PersonIdentifier other &&
        Equals(other);

    public override int GetHashCode() => _value.GetHashCode(StringComparison.Ordinal);

    public bool Equals(PersonIdentifier? other) => Value == other?.Value;

    public override string ToString()
    {
        return _value;
    }
}
