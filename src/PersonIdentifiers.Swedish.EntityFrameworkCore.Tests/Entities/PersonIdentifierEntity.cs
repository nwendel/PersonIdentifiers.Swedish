namespace PersonIdentifiers.Swedish.EntityFrameworkCore.Tests.Entities;

public class PersonIdentifierEntity
{
    public PersonIdentifierEntity(PersonIdentifier identifier)
    {
        Identifier = identifier;
    }

    public int Id { get; set; }

    public PersonIdentifier Identifier { get; set; }
}
