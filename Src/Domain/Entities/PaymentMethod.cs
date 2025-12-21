using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class PaymentMethod : EntityBase
{
    public string Description { get; set; }
    public TypeMethod TypeMethod { get; set; }
}