using Domain.Common;

namespace Domain.Entities;

public class Material : EntityBase
{
    public string Name { get; private set; } 
    public string Path { get; private set; }
    public string Description { get; private set; }
    public DateTime DateCreated { get; private set; }
    public Content Content { get; private set; }
    public Guid  ContentId { get; private set; }
    protected Material(){}
    public Material(string name, string path, string description, DateTime dateCreated, Content content)
    {
        Name = name;
        Path = path;
        Description = description;
        DateCreated = dateCreated;
        Content = content;
        ContentId = content.Id;
    }
}