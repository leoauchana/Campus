using Domain.ValueObjects;

namespace Domain.Entities;

public class Administrator : Person
{
    protected Administrator(){}
    public Administrator(string  firstName, string lastName, Email email, Dni dni, int age, Domicilie domicilie) 
        : base(firstName, lastName, email, dni, age, domicilie) 
    {
    }
}