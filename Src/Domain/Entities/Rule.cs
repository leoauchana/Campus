using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Rule : EntityBase
{
    public TypeRule TypeRule { get; set; }
    public float Value  { get; set; }
}