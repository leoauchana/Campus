using Domain.Common;

namespace Domain.Entities;

public class Fee : EntityBase
{
    public int Number { get; private set; }
    public float Value { get; private set; }
    public Inscription Inscription { get; private set; }
    public Guid InscriptionId { get; private set; }
    protected Fee(){}
    public Fee(int number, float value, Inscription inscription)
    {
        Number = number;
        Value = value;
        Inscription = inscription;
        InscriptionId = inscription.Id;
    }
}