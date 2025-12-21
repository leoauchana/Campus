using Domain.Common;

namespace Domain.Entities;

public class Content : EntityBase
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Class Class { get; private set; }
    public Guid ClassId { get; private set; }
    private readonly List<Material> _materials = new();
    public IReadOnlyCollection<Material> Materials => _materials.AsReadOnly();
    protected Content(){}
    public Content(string name , string description, Class classEntity)
    {
        Name = name;
        Description = description;
        Class = @classEntity;
        ClassId = @classEntity.Id;
    }

    public void AddMaterial(Material material)
    {
        if(material is null)
            throw new ArgumentNullException(nameof(material));
        _materials.Add(material);
    }
}