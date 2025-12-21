using Domain.Common;

namespace Domain.Entities;

public class Person : EntityBase
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Dni { get; set; }
    public int Age { get; set; }
    public Domicilie Domicilie { get; set; }
}