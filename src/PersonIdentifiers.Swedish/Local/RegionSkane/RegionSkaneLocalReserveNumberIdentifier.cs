using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using NodaTime;
using PersonIdentifiers.Swedish.Internal;

namespace PersonIdentifiers.Swedish.Local.RegionSkane;

public sealed class RegionSkaneLocalReserveNumberIdentifier : LocalReserveNumberIdentifier
{
    private static readonly Regex _pattern = new(@"^(\d{6}|\d{8})[D|E|F][A-Z][0|1][A-Z]$");

    private RegionSkaneLocalReserveNumberIdentifier(string value, PersonIdentifierParts parts)
        : base(value, parts)
    {
    }

    public override LocalReserveNumberPrincipal Principal => LocalReserveNumberPrincipal.RegionSkane;

    public override string Oid => PersonIdentifierOids.LocalReserveNumberRegionSkane;

    public static new RegionSkaneLocalReserveNumberIdentifier Parse(string value) =>
        TryParse(value, out var identifier)
            ? identifier
            : throw new RegionSkaneLocalReserveNumberIdentifierFormatException();

    public static bool TryParse(string value, [NotNullWhen(true)] out RegionSkaneLocalReserveNumberIdentifier? identifier)
    {
        GuardAgainst.Null(value);

        identifier = default;
        if (!_pattern.IsMatch(value))
        {
            return false;
        }

        var parts = new RegionSkaneLocalReserveNumberIdentifierParts(value);
        var year = parts.Year;
        if (parts.Kind == RegionSkaneLocalReserveNumberKind.Short)
        {
            // TODO: Add 2000 or 1900 based on some rule
            year += 1900;
        }

        if (!TryGetDateOfBirth(out var dateOfBirth))
        {
            return false;
        }

        identifier = new(value, parts)
        {
            DateOfBirth = dateOfBirth,
            Gender = parts.Gender switch
            {
                '0' => PersonIdentifierGender.Female,
                '1' => PersonIdentifierGender.Male,
                _ => throw new UnreachableCodeException(),
            },
        };
        return true;

        bool TryGetDateOfBirth([NotNullWhen(true)] out LocalDate? dateOfBirth) => parts.Kind switch
        {
            RegionSkaneLocalReserveNumberKind.Short => TryGetDateOfBirthShort(out dateOfBirth),
            RegionSkaneLocalReserveNumberKind.Long => LocalDateHelper.IsValidDate(parts.Year, parts.Month, parts.Day, out dateOfBirth),
        };

        bool TryGetDateOfBirthShort(out LocalDate? dateOfBirth)
        {
            var year = parts.Year + 2000;
            if (LocalDateHelper.IsValidDate(year, parts.Month, parts.Day, out dateOfBirth))
            {
                var now = SystemClock.Instance.GetCurrentInstant();
                var tz = DateTimeZoneProviders.Tzdb.GetSystemDefault();
                var today = now.InZone(tz).Date;
                if (dateOfBirth < today)
                {
                    return true;
                }
            }

            year -= 100;
            if (!LocalDateHelper.IsValidDate(year, parts.Month, parts.Day, out dateOfBirth))
            {
                return false;
            }

            dateOfBirth = new(year, parts.Month, parts.Day);
            return true;
        }
    }
}
