namespace PersonIdentifiers.Swedish.EntityFrameworkCore.Tests.Entities;

public class CoordinationNumberEntity
{
    public CoordinationNumberEntity(CoordinationNumber identifier)
    {
        Identifier = identifier;
    }

    public int Id { get; set; }

    public CoordinationNumber Identifier { get; set; }
}
