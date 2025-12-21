using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Inscription : EntityBase
{
    public DateTime InscriptionDate { get; private set; }
    public StatusInscription Status { get; set; }
    public List<Fee> Fees { get; set; }
    public Alumn Alumn { get; private set; }
    public Guid AlumnId { get; private set; }
    public Administrator Administrator { get; private set; }
    public Guid AdministratorId { get; private set; }
    public Course Course { get; private set; }
    public Guid CourseId { get; private set; }
    protected Inscription(){}
    public Inscription(Alumn alumn, Administrator administrator, Course course, DateTime inscriptionDate)
    {
        InscriptionDate = inscriptionDate;
        Status = StatusInscription.Active;
        Alumn = alumn;
        AlumnId = alumn.Id;
        Administrator = administrator;
        AdministratorId = administrator.Id;
        Course = course;
        CourseId = course.Id;
        Fees = new List<Fee>();
    }
}