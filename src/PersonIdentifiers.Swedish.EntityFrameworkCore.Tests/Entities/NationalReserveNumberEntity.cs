namespace PersonIdentifiers.Swedish.EntityFrameworkCore.Tests.Entities;

public class NationalReserveNumberEntity
{
    public NationalReserveNumberEntity(NationalReserveNumber identifier)
    {
        Identifier = identifier;
    }

    public int Id { get; set; }

    public NationalReserveNumber Identifier { get; set; }
}
