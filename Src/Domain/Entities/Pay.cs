using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Pay : EntityBase
{
    public DateTime PayDate { get; private set; }
    public float Amount { get; private set; }
    public TypeMethod TypeMethod { get; private set; }
    public Fee Fee { get; private set; }
    public  Guid FeeId { get; private set; }
    public Administrator Administrator { get; private set; }
    public Guid AdministratorId { get; private set; }
    protected Pay(){}
    public Pay(float amount, TypeMethod typeMethod, Administrator administrator, Fee fee)
    {
        PayDate = DateTime.Now;
        Amount = amount;
        TypeMethod = typeMethod;
        Administrator = administrator;
        AdministratorId = administrator.Id;
        Fee = fee;
        FeeId = fee.Id;
    }
}