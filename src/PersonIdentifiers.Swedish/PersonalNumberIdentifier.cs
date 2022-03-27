﻿using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text.RegularExpressions;
using NodaTime;
using PersonIdentifiers.Swedish.Internal;

namespace PersonIdentifiers.Swedish;

public sealed class PersonalNumberIdentifier : PersonIdentifier
{
    private static readonly Regex _pattern = new(@"^(\d{2})(\d{2})(\d{2})(([0-3]){1})(\d{1})(([0-9]){4})$");

    private PersonalNumberIdentifier(string value, PersonIdentifierParts parts)
        : base(value, parts)
    {
    }

    public override PersonIdentifierKind Kind => PersonIdentifierKind.PersonalNumber;

    public override string Oid => PersonIdentifierOids.PersonalNumber;

    // TODO: Is this the best design?
    [NotNull]
    public override LocalDate? DateOfBirth
    {
        get => base.DateOfBirth!;
        protected set => base.DateOfBirth = value;
    }

    // TODO: Is this the best design?
    [NotNull]
    public override PersonIdentifierGender? Gender
    {
        get => base.Gender!;
        protected set => base.Gender = value;
    }

    public static bool TryParse(string value, [NotNullWhen(true)] out PersonalNumberIdentifier? identifier)
    {
        GuardAgainst.Null(value);

        identifier = default;
        if (!_pattern.IsMatch(value) || !Luhn.IsValid(value[2..]))
        {
            return false;
        }

        var parts = new PersonIdentifierParts(value);
        var year = int.Parse(parts.Year, CultureInfo.CurrentCulture);
        var month = int.Parse(parts.Month, CultureInfo.CurrentCulture);
        var day = int.Parse(parts.Day, CultureInfo.CurrentCulture);
        if (LocalDateHelper.IsInvalidDate(year, month, day))
        {
            return false;
        }

        identifier = new PersonalNumberIdentifier(value, parts)
        {
            DateOfBirth = new LocalDate(year, month, day),
            Gender = GetGender(),
        };

        return true;

        PersonIdentifierGender GetGender()
        {
            var genderDigit = parts.Gender[0] - '0';
            return genderDigit.IsOdd()
                ? PersonIdentifierGender.Male
                : PersonIdentifierGender.Female;
        }
    }
}
