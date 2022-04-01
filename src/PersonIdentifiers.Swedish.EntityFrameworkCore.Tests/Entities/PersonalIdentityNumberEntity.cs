namespace PersonIdentifiers.Swedish.EntityFrameworkCore.Tests.Entities;

public class PersonalIdentityNumberEntity
{
    public PersonalIdentityNumberEntity(PersonalIdentityNumber identifier)
    {
        Identifier = identifier;
    }

    public int Id { get; set; }

    public PersonalIdentityNumber Identifier { get; set; }
}
