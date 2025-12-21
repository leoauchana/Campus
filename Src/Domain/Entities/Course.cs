using Domain.Common;

namespace Domain.Entities;

public class Course : EntityBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public float PriceBase { get; set; }
    public float PriceEnd { get; set; }
}