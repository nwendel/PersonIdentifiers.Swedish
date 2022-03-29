namespace PersonIdentifiers.Swedish.EntityFrameworkCore.Tests.Entities;

public class NationalReserveNumberIdentifierEntity
{
    public NationalReserveNumberIdentifierEntity(NationalReserveNumberIdentifier identifier)
    {
        Identifier = identifier;
    }

    public int Id { get; set; }

    public NationalReserveNumberIdentifier Identifier { get; set; }
}
