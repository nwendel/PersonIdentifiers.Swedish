﻿using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using NodaTime;
using PersonIdentifiers.Swedish.Internal;

namespace PersonIdentifiers.Swedish;

public sealed class PersonalNumberIdentifier :
    PersonIdentifier,
    IPersonIdentifierPartsAware<StandardPersonIdentifierParts>
{
    private static readonly Regex _pattern = new(@"^(\d{2})(\d{2})(\d{2})(([0-3]){1})(\d{1})(([0-9]){4})$");

    private PersonalNumberIdentifier(string value, StandardPersonIdentifierParts parts)
        : base(value, parts)
    {
    }

    public override PersonIdentifierKind Kind => PersonIdentifierKind.PersonalNumber;

    public override string Oid => PersonIdentifierOids.PersonalNumber;

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

    public static new PersonalNumberIdentifier Parse(string value) =>
        TryParse(value, out var identifier)
            ? identifier
            : throw new PersonalNumberIdentifierFormatException();

    public static bool TryParse(string value, [NotNullWhen(true)] out PersonalNumberIdentifier? identifier)
    {
        GuardAgainst.Null(value);

        identifier = default;
        if (!_pattern.IsMatch(value) || !Luhn.IsValid(value[2..]))
        {
            return false;
        }

        var parts = new StandardPersonIdentifierParts(value);
        if (LocalDateHelper.IsInvalidDate(parts.Year, parts.Month, parts.Day))
        {
            return false;
        }

        identifier = new PersonalNumberIdentifier(value, parts)
        {
            DateOfBirth = new(parts.Year, parts.Month, parts.Day),
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
