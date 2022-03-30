using PersonIdentifiers.Swedish.Internal;

namespace PersonIdentifiers.Swedish;

public static class PersonIdentifierOids
{
    public const string PersonalNumber = "1.2.752.129.2.1.3.1";

    public const string CoordinationNumber = "1.2.752.129.2.1.3.3";

    public const string NationalReserveNumber = "1.2.752.129.2.1.3.3";

    public static string GetOid(PersonIdentifierKind kind)
    {
        GuardAgainst.Undefined(kind);

        var oid = kind switch
        {
            PersonIdentifierKind.PersonalNumber => PersonalNumber,
            PersonIdentifierKind.CoordinationNumber => CoordinationNumber,
            PersonIdentifierKind.NationalReserveNumber => NationalReserveNumber,
        };
        return oid;
    }
}
