using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Pay : EntityBase
{
    public DateTime PayDate { get; private set; }
    public float Amount { get; private set; }
    public TypeMethod TypeMethod { get; private set; }

    private readonly List<Fee> _fees = new();
    public IReadOnlyCollection<Fee> Fees => _fees.AsReadOnly();
    public Administrator Administrator { get; private set; }
    public Guid AdministratorId { get; private set; }
    protected Pay(){}
    public Pay(float amount, TypeMethod typeMethod, Administrator administrator)
    {
        PayDate = DateTime.Now;
        Amount = amount;
        TypeMethod = typeMethod;
        Administrator = administrator;
        AdministratorId = administrator.Id;
    }

    public void AddFee(Fee fee)
    {
        if(fee is null)
            throw new ArgumentNullException(nameof(fee));
        _fees.Add(fee);
    }
}