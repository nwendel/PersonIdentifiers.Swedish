﻿using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using NodaTime;
using PersonIdentifiers.Swedish.Internal;

namespace PersonIdentifiers.Swedish;

public sealed class CoordinationNumberIdentifier :
    PersonIdentifier,
    IPersonIdentifierPartsAware<StandardPersonIdentifierParts>
{
    private static readonly Regex _pattern = new(@"^(\d{2})(\d{2})(\d{2})(([6-9]){1})(\d{1})(([0-9]){4})$");

    private CoordinationNumberIdentifier(string value, StandardPersonIdentifierParts parts)
        : base(value, parts)
    {
    }

    public override PersonIdentifierKind Kind => PersonIdentifierKind.CoordinationNumber;

    public override string Oid => PersonIdentifierOids.CoordinationNumber;

    public override StandardPersonIdentifierParts Parts => (StandardPersonIdentifierParts)base.Parts;

    public new LocalDate DateOfBirth
    {
        get => base.DateOfBirth ?? throw new UnreachableCodeException();
        private set => base.DateOfBirth = value;
    }

    public new PersonIdentifierGender Gender
    {
        get => base.Gender ?? throw new UnreachableCodeException();
        private set => base.Gender = value;
    }

    public static new CoordinationNumberIdentifier Parse(string value) =>
        TryParse(value, out var identifier)
            ? identifier
            : throw new CoordinationNumberIdentifierFormatException();

    public static bool TryParse(string value, [NotNullWhen(true)] out CoordinationNumberIdentifier? identifier)
    {
        GuardAgainst.Null(value);

        identifier = default;
        if (!_pattern.IsMatch(value) || !Luhn.IsValid(value[2..]))
        {
            return false;
        }

        var parts = new StandardPersonIdentifierParts(value);
        var day = parts.Day - 60;

        if (LocalDateHelper.IsInvalidDate(parts.Year, parts.Month, day))
        {
            return false;
        }

        identifier = new CoordinationNumberIdentifier(value, parts)
        {
            DateOfBirth = new LocalDate(parts.Year, parts.Month, day),
            Gender = GetGender(),
        };

        return true;

        PersonIdentifierGender GetGender()
        {
            var genderDigit = parts.Gender - '0';
            return genderDigit.IsOdd()
                ? PersonIdentifierGender.Male
                : PersonIdentifierGender.Female;
        }
    }
}
