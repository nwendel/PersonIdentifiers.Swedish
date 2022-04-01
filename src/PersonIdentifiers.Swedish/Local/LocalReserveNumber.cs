using System.Diagnostics.CodeAnalysis;
using PersonIdentifiers.Swedish.Options;

namespace PersonIdentifiers.Swedish.Local;

public abstract class LocalReserveNumber : PersonIdentifier
{
    protected LocalReserveNumber(string value, PersonIdentifierParts parts)
        : base(value, parts)
    {
    }

    public override PersonIdentifierKind Kind => PersonIdentifierKind.LocalReserveNumber;

    public abstract LocalReserveNumberPrincipal Principal { get; }

    public static new LocalReserveNumber Parse(string value) =>
        TryParse(value, out var identifier)
            ? identifier
            : throw new LocalReserveNumberFormatException();

    public static new LocalReserveNumber Parse(string value, PersonIdentifierParseOptions options) =>
        TryParse(value, options, out var identifier)
            ? identifier
            : throw new PersonIdentifierFormatException();

    public static bool TryParse(string value, [NotNullWhen(true)] out LocalReserveNumber? identifier) =>
        TryParse(value, PersonIdentifierParseOptions.Default, out identifier);

    public static bool TryParse(string value, PersonIdentifierParseOptions options, [NotNullWhen(true)] out LocalReserveNumber? identifier)
    {
        throw new NotImplementedException();
    }
}
