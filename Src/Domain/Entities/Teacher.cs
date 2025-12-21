using Domain.ValueObjects;

namespace Domain.Entities;

public class Teacher :  Person
{
    public string Phone {get; private set;}
    public User User { get; private set; }
    public Guid UserId { get; private set; }
    protected Teacher(){}
    public Teacher(string  firstName, string lastName, Email email, Dni dni, int age, Domicilie domicilie, string phone, User user) 
        : base(firstName, lastName, email, dni, age, domicilie)
    {
        Phone = phone ??  throw new ArgumentNullException(nameof(phone));
        User = user ?? throw new ArgumentNullException(nameof(user));
        UserId = user.Id;
    }
}