namespace Domain.Entities;

public class Domicilie
{
    public string Street { get; private set; }
    public string City { get; private set; }
    public int Number { get; private set; }
    protected Domicilie(){}
    public Domicilie(string street, string city, int number)
    {
        Street = street;
        City = city;
        Number = number;
    }
}