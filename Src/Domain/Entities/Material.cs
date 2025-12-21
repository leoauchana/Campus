using Domain.Common;

namespace Domain.Entities;

public class Material : EntityBase
{
    public string Name { get; set; } 
    public string Path { get; set; }
    public string Description { get; set; }
    public DateTime DateCreated { get; set; }
}