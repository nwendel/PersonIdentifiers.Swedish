using System.Diagnostics.CodeAnalysis;
using PersonIdentifiers.Swedish.Internal;
using PersonIdentifiers.Swedish.LocalReserveNumbers.RegionSkane;
using PersonIdentifiers.Swedish.Parts;

namespace PersonIdentifiers.Swedish.LocalReserveNumbers;

public abstract class LocalReserveNumber : PersonIdentifier
{
    protected LocalReserveNumber(string value, PersonIdentifierParts parts)
        : base(value, parts)
    {
    }

    public override PersonIdentifierKind Kind => PersonIdentifierKind.LocalReserveNumber;

    public abstract LocalReserveNumberPrincipal Principal { get; }

    public static LocalReserveNumber Parse(string value, LocalReserveNumberPrincipal principal) =>
        TryParse(value, principal, out var identifier)
            ? identifier
            : throw new PersonIdentifierFormatException(typeof(LocalReserveNumber));

    public static bool TryParse(string value, LocalReserveNumberPrincipal principal, [NotNullWhen(true)] out LocalReserveNumber? identifier)
    {
        GuardAgainst.Null(value);
        GuardAgainst.Undefined(principal);

        identifier = principal switch
        {
            LocalReserveNumberPrincipal.RegionSkane => RegionSkaneLocalReserveNumber.TryParse(value, out var localReserveNumer) ? localReserveNumer : null,
            _ => throw new NotImplementedException($"LocalReserveNumberPrincipal {principal} is not yet supported"),
        };

        return identifier != null;
    }
}
