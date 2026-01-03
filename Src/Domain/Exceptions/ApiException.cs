namespace Domain.Exceptions;

public class ApiException
{
    private int Status { get; set; }
    private string? Message { get; set; }
    private string? Detail { get; set; }

    public ApiException(int status, string? message = null, string? detail = null)
    {
        Status = status;
        Message = message;
        Detail = detail;
    }
}