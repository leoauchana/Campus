using Domain.Common;

namespace Domain.Entities;

public class Fee : EntityBase
{
    public int Number { get; set; }
    public float Value { get; set; }
    public bool IsActive { get; set; }
    protected Fee(){}
    public Fee(int number, float value)
    {
        Number = number;
        Value = value;
    }
}