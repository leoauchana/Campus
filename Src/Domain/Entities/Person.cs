using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities;

public abstract class Person : EntityBase
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Email Email { get; set; }
    public Dni Dni { get; set; }
    public int Age { get; set; }
    public Domicilie Domicilie { get; set; }
    protected Person(){}

    protected Person(string  firstName, string lastName, Email email, Dni dni, int age, Domicilie domicilie)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Dni = dni;
        Age = age;
        Domicilie = domicilie;
    }
}