using Domain.Common;

namespace Domain.Entities;

public class Class : EntityBase
{
    public int Number { get; set; }
    public string Description { get; set; }
}