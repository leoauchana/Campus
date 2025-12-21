using Domain.ValueObjects;

namespace Domain.Entities;

public class Alumn : Person
{
    public User User { get; private set; }
    public Guid UserId { get; private set; }
    protected Alumn(){}
    public Alumn(string firstName, string lastName, Email email, Dni dni, int age, Domicilie domicilie, User user)
        : base(firstName, lastName, email, dni, age, domicilie)
    {
        User = user ?? throw new ArgumentNullException(nameof(user));
        UserId = user.Id;
    }
}