using System.Diagnostics.CodeAnalysis;
using PersonIdentifiers.Swedish.Internal;
using PersonIdentifiers.Swedish.Local.RegionSkane;
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
        Parse(value, PersonIdentifierParseOptions.Default);

    public static new LocalReserveNumber Parse(string value, PersonIdentifierParseOptions options) =>
        TryParse(value, options, out var identifier)
            ? identifier
            : throw new PersonIdentifierFormatException();

    public static bool TryParse(string value, [NotNullWhen(true)] out LocalReserveNumber? identifier) =>
        TryParse(value, PersonIdentifierParseOptions.Default, out identifier);

    // TODO: Which options to pass in here?
    public static bool TryParse(string value, PersonIdentifierParseOptions options, [NotNullWhen(true)] out LocalReserveNumber? identifier)
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

        List<Func<LocalReserveNumber?>> GetParsers()
        {
            // TODO: Which parsers to add?
            //       Support multiple at same time or just one?
            // TODO: How to deal with options which are specific to local implementations?
            var parsers = new List<Func<LocalReserveNumber?>>
            {
                () => RegionSkaneLocalReserveNumber.TryParse(value, RegionSkaneLocalReserveNumberOptions.Default, out var localReserveNumber) ? localReserveNumber : null,
            };

            return parsers;
        }
    }
}
