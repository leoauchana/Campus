using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Pay : EntityBase
{
    public DateTime  PayDate { get; set; }
    public float Amount { get; set; }
    public TypeMethod  TypeMethod { get; set; } 
}