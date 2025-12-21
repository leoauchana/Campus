using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class PaymentMethod : EntityBase
{
    public string Description { get; private set; }
    public TypeMethod TypeMethod { get; private set; }
    protected PaymentMethod(){}
    public PaymentMethod(string description, TypeMethod typeMethod)
    {
        Description = description;
        TypeMethod = typeMethod;
    }
}