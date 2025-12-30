using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Inscription : EntityBase
{
    public DateTime InscriptionDate { get; private set; }
    public StatusInscription Status { get; private set; }
    public Fee Fee { get; private set; }
    public Alumn Alumn { get; private set; }
    public Guid AlumnId { get; private set; }
    public Administrator Administrator { get; private set; }
    public Guid AdministratorId { get; private set; }
    public Course Course { get; private set; }
    public Guid CourseId { get; private set; }
    protected Inscription(){}
    public Inscription(Alumn alumn, Administrator administrator, Course course, Fee fee, DateTime inscriptionDate)
    {
        InscriptionDate = inscriptionDate;
        Status = StatusInscription.Active;
        Alumn = alumn;
        AlumnId = alumn.Id;
        Administrator = administrator;
        AdministratorId = administrator.Id;
        Course = course;
        CourseId = course.Id;
        Fee = fee;
    }

    public void UpdateStatusInscription(StatusInscription statusInscription)
    {
        Status = statusInscription;
    }
}