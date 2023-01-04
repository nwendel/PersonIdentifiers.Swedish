using PersonIdentifiers.Swedish.Internal;
using PersonIdentifiers.Swedish.LocalReserveNumbers;

namespace PersonIdentifiers.Swedish;

public static class PersonIdentifierOids
{
    public const string PersonalIdentityNumber = "1.2.752.129.2.1.3.1";

    public const string CoordinationNumber = "1.2.752.129.2.1.3.3";

    public const string NationalReserveNumber = "1.2.752.74.9.1";

    public const string LocalReserveNumberIneraCarelink = "1.2.752.129.2.1.3.2";

    public const string LocalReserveNumberLandstingetVarmland = "1.2.752.74.9.2";

    public const string LocalReserveNumberRegionBlekinge = "1.2.752.74.9.5";

    public const string LocalReserveNumberRegionOrebroLan = "1.2.752.74.9.3";

    public const string LocalReserveNumberRegionSkane = "1.2.752.74.9.4";

    public const string LocalReserveNumberRegionSormland1 = "1.2.752.266.1.1.1";

    public const string LocalReserveNumberRegionSormland2 = "1.2.752.266.1.1.2";

    public const string LocalReserveNumberRegionStockholm = "1.2.752.97.3.1.3";

    public const string LocalReserveNumberRegionVasternorrland = "1.2.752.269.1.1";

    public const string LocalReserveNumberVastraGotalandsregionen = "1.2.752.113.11.0.2.1.1.1";

    public static string GetOid(PersonIdentifierKind kind)
    {
        GuardAgainst.Undefined(kind);

        var oid = kind switch
        {
            PersonIdentifierKind.PersonalIdentityNumber => PersonalIdentityNumber,
            PersonIdentifierKind.CoordinationNumber => CoordinationNumber,
            PersonIdentifierKind.NationalReserveNumber => NationalReserveNumber,
            PersonIdentifierKind.LocalReserveNumber => throw new ArgumentException($"Cannot get Oid for LocalReserveNumber, use {nameof(GetLocalReserveNumberOid)}"),
        };
        return oid;
    }

    // TODO: Should constants for local reserve numbers and this method be in this class?
    // TODO: How to deal with Sörmland which has two different Oids?
    //       Perhaps this method should return an IEnumerable<string> instead?
    public static string GetLocalReserveNumberOid(LocalReserveNumberPrincipal principal)
    {
        GuardAgainst.Undefined(principal);

        var oid = principal switch
        {
            LocalReserveNumberPrincipal.IneraCarelink => LocalReserveNumberIneraCarelink,
            LocalReserveNumberPrincipal.LandstingetVarmland => LocalReserveNumberLandstingetVarmland,
            LocalReserveNumberPrincipal.RegionBlekinge => LocalReserveNumberRegionBlekinge,
            LocalReserveNumberPrincipal.RegionOrebroLan => LocalReserveNumberRegionOrebroLan,
            LocalReserveNumberPrincipal.RegionSkane => LocalReserveNumberRegionSkane,
            LocalReserveNumberPrincipal.RegionSormland => throw new NotImplementedException("There are two what to do here?"),
            LocalReserveNumberPrincipal.RegionStockholm => LocalReserveNumberRegionStockholm,
            LocalReserveNumberPrincipal.RegionVasternorrland => LocalReserveNumberRegionVasternorrland,
            LocalReserveNumberPrincipal.VastraGotalandsregionen => LocalReserveNumberVastraGotalandsregionen,
        };

        return oid;
    }
}
