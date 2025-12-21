using Domain.Common;

namespace Domain.Entities;

public class User : EntityBase
{
    public string UserName { get; private set; }
    public string Password { get; private set; }
    protected User(){}
    public User(string username, string password)
    {
        UserName = username;
        Password = password;
    }
}