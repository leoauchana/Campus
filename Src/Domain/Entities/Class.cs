using Domain.Common;

namespace Domain.Entities;

public class Class : EntityBase
{
    public int Number { get; private set; }
    public string Description { get; private set; }
    public Course Course { get; private set; }
    public Guid CourseId { get; private set; }
    private readonly List<Content> _contents = new();
    public IReadOnlyCollection<Content> Contents => _contents.AsReadOnly();
    protected Class(){}
    public Class(int number, string description, Course course)
    {
        Number = number;
        Description = description;
        Course = course;
        CourseId =  course.Id;
    }

    public void AddContent(Content content)
    {
        if(content is null)
            throw new ArgumentNullException(nameof(content));
        _contents.Add(content);
    }
}