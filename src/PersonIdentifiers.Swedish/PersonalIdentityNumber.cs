﻿using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using PersonIdentifiers.Swedish.Internal;

namespace PersonIdentifiers.Swedish;

// https://www.skatteverket.se/servicelankar/otherlanguages/inenglish/individualsandemployees/livinginsweden/personalidentitynumberandcoordinationnumber.4.2cf1b5cd163796a5c8b4295.html
public sealed class PersonalIdentityNumber :
    PersonIdentifier,
    IPersonIdentifierPartsAware<StandardPersonIdentifierParts>
{
    private static readonly Regex _pattern = new(@"^(\d{2})(\d{2})(\d{2})(([0-3]){1})(\d{1})(([0-9]){4})$");

    private PersonalIdentityNumber(string value, StandardPersonIdentifierParts parts)
        : base(value, parts)
    {
    }

    public override PersonIdentifierKind Kind => PersonIdentifierKind.PersonalIdentityNumber;

    public override string Oid => PersonIdentifierOids.PersonalNumber;

    public override StandardPersonIdentifierParts Parts => (StandardPersonIdentifierParts)base.Parts;

    public new DateOnly DateOfBirth
    {
        get => base.DateOfBirth ?? throw new UnreachableCodeException($"{nameof(DateOfBirth)} is null");
        private set => base.DateOfBirth = value;
    }

    public new PersonIdentifierGender Gender
    {
        get => base.Gender ?? throw new UnreachableCodeException($"{nameof(Gender)} is null");
        private set => base.Gender = value;
    }

    public static new PersonalIdentityNumber Parse(string value) =>
        TryParse(value, out var identifier)
            ? identifier
            : throw new PersonalIdentityNumberFormatException();

    public static bool TryParse(string value, [NotNullWhen(true)] out PersonalIdentityNumber? identifier)
    {
        GuardAgainst.Null(value);

        identifier = default;
        if (!_pattern.IsMatch(value) || !Luhn.IsValid(value[2..]))
        {
            return false;
        }

        var parts = new StandardPersonIdentifierParts(value);
        if (!LocalDateHelper.IsValidDate(parts.Year, parts.Month, parts.Day, out var dateOfBirth))
        {
            return false;
        }

        identifier = new PersonalIdentityNumber(value, parts)
        {
            DateOfBirth = dateOfBirth.Value,
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