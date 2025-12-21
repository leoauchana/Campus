using Domain.Common;

namespace Domain.Entities;

public class Fee : EntityBase
{
    public int Number { get; set; }
    public float Value { get; set; }
}