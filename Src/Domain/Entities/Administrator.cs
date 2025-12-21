namespace Domain.Entities;

public class Administrator : Person
{
    protected Administrator(){}
    public Administrator(string  firstName, string lastName, string email, string dni, int age, Domicilie domicilie) 
        : base(firstName, lastName, email, dni, age, domicilie) 
    {
    }
}