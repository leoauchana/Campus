using Domain.Common;

namespace Domain.Entities;

public abstract class Person : EntityBase
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Dni { get; set; }
    public int Age { get; set; }
    public Domicilie Domicilie { get; set; }
    protected Person(){}

    protected Person(string  firstName, string lastName, string email, string dni, int age, Domicilie domicilie)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Dni = dni;
        Age = age;
        Domicilie = domicilie;
    }
}