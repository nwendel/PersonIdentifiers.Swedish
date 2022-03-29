namespace PersonIdentifiers.Swedish.EntityFrameworkCore.Tests.Entities;

public class PersonalNumberIdentifierEntity
{
    public PersonalNumberIdentifierEntity(PersonalNumberIdentifier identifier)
    {
        Identifier = identifier;
    }

    public int Id { get; set; }

    public PersonalNumberIdentifier Identifier { get; set; }
}
