using System.ComponentModel.DataAnnotations;

namespace Transversal.Configurations;

public class DatabaseOptions
{
    public const string Section = "Database";
    [Required]
    public string SqlServerConnection { get; set; } = string.Empty;
}