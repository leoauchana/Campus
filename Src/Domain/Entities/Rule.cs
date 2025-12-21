using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Rule : EntityBase
{
    public TypeRule TypeRule { get; set; }
    public float Value  { get; set; }
    protected Rule(){}
    public Rule(TypeRule typeRule, float value)
    {
        TypeRule = typeRule;
        Value = value;
    }
}