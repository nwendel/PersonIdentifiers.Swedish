namespace PersonIdentifiers.Swedish.EntityFrameworkCore.Tests.Entities;

public class CoordinationNumberIdentifierEntity
{
    public CoordinationNumberIdentifierEntity(CoordinationNumberIdentifier identifier)
    {
        Identifier = identifier;
    }

    public int Id { get; set; }

    public CoordinationNumberIdentifier Identifier { get; set; }
}
