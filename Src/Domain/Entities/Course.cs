using Domain.Common;

namespace Domain.Entities;

public class Course : EntityBase
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public float PriceBase { get; private set; }
    public float PriceEnd { get; private set; }
    public Inscription Inscription { get; private set; }
    public Rule Rule { get; private set; }
    public Guid RuleId { get; private set; }
    public Teacher Teacher { get; private set; }
    public Guid TeacherId { get; private set; }
    private readonly List<Class> _classes = new();
    public IReadOnlyCollection<Class> Classes => _classes.AsReadOnly();

    protected Course(){}

    public Course(string name, string description, float priceBase, float priceEnd, Inscription inscription,
     Rule rule, Teacher teacher)
    {
        Name = name;
        Description = description;
        PriceBase = priceBase;
        PriceEnd = priceEnd;
        Inscription = inscription;
        Rule = rule;
        RuleId = rule.Id;
        Teacher = teacher;
        TeacherId = teacher.Id;
    }
    public void AddClass(Class classEntity)
    {
        if (@classEntity is null)
            throw new ArgumentNullException(nameof(@classEntity));

        _classes.Add(@classEntity);
    }
}