namespace Application.DTOs;

public class TeacherDto
{
    public record RequestCreate(string firstName, string lastName, string email, string dni, 
        int age, string city, string street, int number, string phone, string userName, string password);
    
    public record RequestUpdate(string id, string? firstName, string? lastName, string? email, string? dni, 
        int? age, string? city, string? street, int? number, string? phone);

    public record Response();
}