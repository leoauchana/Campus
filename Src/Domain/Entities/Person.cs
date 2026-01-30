using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities;

public abstract class Person : EntityBase
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public Email Email { get; private set; }
    public Dni Dni { get; private set; }
    public int Age { get; private set; }
    public Domicilie Domicilie { get; private set; }

    protected Person()
    {
    }

    protected Person(string firstName, string lastName, Email email, Dni dni, int age, Domicilie domicilie)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Dni = dni;
        Age = age;
        Domicilie = domicilie;
    }

    protected void UpdateFirstName(string newFirstName)
    {
        if (string.IsNullOrEmpty(newFirstName) || string.IsNullOrWhiteSpace(newFirstName))
            throw new ArgumentException("El nombre es inválido");
        FirstName = newFirstName;
    }

    protected void UpdateLastName(string newLastName)
    {
        if (string.IsNullOrEmpty(newLastName) || string.IsNullOrWhiteSpace(newLastName))
            throw new ArgumentException("El apellido es inválido");
        LastName = newLastName;
    }

    protected void UpdateEmail(string newEmail)
    {
        if (string.IsNullOrEmpty(newEmail) || string.IsNullOrWhiteSpace(newEmail))
            throw new ArgumentException("El email es inválido");
        Email = Email.Create(newEmail);
    }
    protected void UpdateDni(string newDni)
    {
        if (string.IsNullOrEmpty(newDni) || string.IsNullOrWhiteSpace(newDni))
            throw new ArgumentException("El dni es inválido");
        Dni = Dni.Create(newDni);
    }
    protected void UpdateAge(int newAge)
    {
        Age = newAge;
    }
    protected void UpdateCity(string newCity)
    {
        if (string.IsNullOrEmpty(newCity) || string.IsNullOrWhiteSpace(newCity)) throw new ArgumentException("La ciudad es inválida.");
        //Domicilie.City = newCity;
    }
    protected void UpdateStreet(string newStreet)
    {
        if (string.IsNullOrEmpty(newStreet) || string.IsNullOrWhiteSpace(newStreet)) throw new ArgumentException("La calle es inválida.");
        //Domicilie.City = newCity;
    }
    protected void UpdateDomicilieNumber(int newNumber)
    {
        
    }
    
    
}