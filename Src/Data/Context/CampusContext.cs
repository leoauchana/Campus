using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context;

public class CampusContext : DbContext
{
    public CampusContext(DbContextOptions<CampusContext> options) : base(options)
    {
    }
    public DbSet<Administrator> Administrators { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Alumn>  Alumns { get; set; }
    public DbSet<Inscription>  Inscriptions { get; set; }
    public DbSet<Fee>  Fees { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Content>  Contents { get; set; }
    public DbSet<Material>  Materials { get; set; }
    public DbSet<Pay> Pays  { get; set; }
    public DbSet<Rule>  Rules { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        AdminConfig(modelBuilder);
        UserConfig(modelBuilder);
        TeacherConfig(modelBuilder);
        AlumnConfig(modelBuilder);
        InscriptionConfig(modelBuilder);
        FeeConfig(modelBuilder);
        ClassConfig(modelBuilder);
        CourseConfig(modelBuilder);
        ContentConfig(modelBuilder);
        MaterialConfig(modelBuilder);
        PayConfig(modelBuilder);
        RuleConfig(modelBuilder);
    }
    private void AdminConfig(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrator>()
            .ToTable("Administrators")
            .HasKey(a => a.Id);
        modelBuilder.Entity<Administrator>()
            .Property(a => a.FirstName)
            .HasMaxLength(50)
            .IsRequired();
        modelBuilder.Entity<Administrator>()
            .Property(a => a.LastName)
            .HasMaxLength(50)
            .IsRequired();
        modelBuilder.Entity<Administrator>()
            .Property(a => a.Age)
            .HasColumnType("int")
            .IsRequired();
        modelBuilder.Entity<Administrator>()
            .Property(a => a.Dni)
            .HasColumnType("varchar")
            .IsRequired();
        modelBuilder.Entity<Administrator>()
            .Property(a => a.Domicilie.City)
            .HasColumnType("varchar")
            .HasMaxLength(30)
            .IsRequired();
        modelBuilder.Entity<Administrator>()
            .Property(a => a.Domicilie.Street)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();
        modelBuilder.Entity<Administrator>()
            .Property(a => a.Domicilie.Number)
            .HasColumnType("int")
            .IsRequired();
        modelBuilder.Entity<Administrator>()
            .Property(a => a.Email)
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();
    }
    private void UserConfig(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .ToTable("Users")
            .HasKey(a => a.Id);
        modelBuilder.Entity<User>()
            .Property(u => u.UserName)
            .HasMaxLength(20)
            .IsRequired();
        modelBuilder.Entity<User>()
            .Property(u => u.Password)
            .HasMaxLength(20)
            .IsRequired();
    }
    private void AlumnConfig(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumn>()
            .ToTable("Alumns")
            .HasKey(a => a.Id);
        modelBuilder.Entity<Alumn>()
            .Property(a => a.FirstName)
            .HasMaxLength(50)
            .IsRequired();
        modelBuilder.Entity<Alumn>()
            .Property(a => a.LastName)
            .HasMaxLength(50)
            .IsRequired();
        modelBuilder.Entity<Alumn>()
            .Property(a => a.Age)
            .HasColumnType("int")
            .IsRequired();
        modelBuilder.Entity<Alumn>()
            .Property(a => a.Dni)
            .HasColumnType("varchar")
            .IsRequired();
        modelBuilder.Entity<Alumn>()
            .Property(a => a.Domicilie.City)
            .HasColumnType("varchar")
            .HasMaxLength(30)
            .IsRequired();
        modelBuilder.Entity<Alumn>()
            .Property(a => a.Domicilie.Street)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();
        modelBuilder.Entity<Alumn>()
            .Property(a => a.Domicilie.Number)
            .HasColumnType("int")
            .IsRequired();
        modelBuilder.Entity<Alumn>()
            .Property(a => a.Email)
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();
    }
    private void TeacherConfig(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Teacher>()
            .ToTable("Teachers")
            .HasKey(a => a.Id);
        modelBuilder.Entity<Teacher>()
            .Property(a => a.FirstName)
            .HasMaxLength(50)
            .IsRequired();
        modelBuilder.Entity<Teacher>()
            .Property(a => a.LastName)
            .HasMaxLength(50)
            .IsRequired();
        modelBuilder.Entity<Teacher>()
            .Property(a => a.Age)
            .HasColumnType("int")
            .IsRequired();
        modelBuilder.Entity<Teacher>()
            .Property(a => a.Dni)
            .HasColumnType("varchar")
            .IsRequired();
        modelBuilder.Entity<Teacher>()
            .Property(a => a.Domicilie.City)
            .HasColumnType("varchar")
            .HasMaxLength(30)
            .IsRequired();
        modelBuilder.Entity<Teacher>()
            .Property(a => a.Domicilie.Street)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();
        modelBuilder.Entity<Teacher>()
            .Property(a => a.Domicilie.Number)
            .HasColumnType("int")
            .IsRequired();
        modelBuilder.Entity<Teacher>()
            .Property(a => a.Email)
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();
        modelBuilder.Entity<Teacher>()
            .Property(a => a.Phone)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();
    }
    private void InscriptionConfig(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Inscription>()
            .ToTable("Inscriptions")
            .HasKey(i => i.Id);
        modelBuilder.Entity<Inscription>()
            .Property(i => i.InscriptionDate)
            .IsRequired();
        modelBuilder.Entity<Inscription>()
            .Property(i => i.Status)
            .IsRequired();
    }
    private void FeeConfig(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Fee>()
            .ToTable("Fees")
            .HasKey(f => f.Id);
        modelBuilder.Entity<Fee>()
            .Property(f => f.Value)
            .HasColumnType("float")
            .IsRequired();
        modelBuilder.Entity<Fee>()
            .Property(f => f.Number)
            .HasColumnType("int")
            .IsRequired();
    }
    private void ClassConfig(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>()
                .HasKey(c => c.Id);
        modelBuilder.Entity<Class>()
                .Property(c => c.Number)
                .HasColumnType("int")
                .IsRequired();
        modelBuilder.Entity<Class>()
            .Property(c => c.Description)
            .HasColumnType("varchar")
            .HasMaxLength(450)
            .IsRequired();
    }
    private void CourseConfig(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>()
            .ToTable("Courses")
            .HasKey(c => c.Id);
        modelBuilder.Entity<Course>()
            .ToTable("Courses")
            .Property(c => c.Description)
            .HasColumnType("varchar")
            .HasMaxLength(450)
            .IsRequired();
        modelBuilder.Entity<Course>()
            .Property(c => c.Name)
            .HasColumnType("varchar")
            .HasMaxLength(30)
            .IsRequired();
        modelBuilder.Entity<Course>()
            .Property(c => c.PriceBase)
            .HasColumnType("float")
            .IsRequired();
        modelBuilder.Entity<Course>()
            .Property(c => c.PriceEnd)
            .HasColumnType("float")
            .IsRequired();
    }
    private void ContentConfig(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Content>()
            .ToTable("Contents")
            .HasKey(c => c.Id);
        modelBuilder.Entity<Content>()
            .Property(c => c.Name)
            .HasColumnType("varchar")
            .HasMaxLength(30)
            .IsRequired();
        modelBuilder.Entity<Content>()
            .Property(c => c.Description)
            .HasColumnType("varchar")
            .HasMaxLength(450)
            .IsRequired();
    }
    private void MaterialConfig(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Material>()
            .ToTable("Materials")
            .HasKey(m => m.Id);
        modelBuilder.Entity<Material>()
            .Property(m => m.Name)
            .HasColumnType("varchar")
            .HasMaxLength(30)
            .IsRequired();
        modelBuilder.Entity<Material>()
            .Property(m => m.Description)
            .HasColumnType("varchar")
            .HasMaxLength(450)
            .IsRequired();
        modelBuilder.Entity<Material>()
            .Property(m => m.DateCreated)
            .IsRequired();
        modelBuilder.Entity<Material>()
            .Property(m => m.Path)
            .HasColumnType("varchar")
            .HasMaxLength(255)
            .IsRequired();
    }
    private void PayConfig(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pay>()
            .ToTable("Pays")
            .HasKey(p => p.Id);
        modelBuilder.Entity<Pay>()
            .Property(p => p.TypeMethod)
            .IsRequired();
        modelBuilder.Entity<Pay>()
            .Property(p => p.PayDate)
            .IsRequired();
        modelBuilder.Entity<Pay>()
            .Property(p => p.Amount)
            .HasColumnType("float")
            .IsRequired();
    }
    private void RuleConfig(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Rule>()
            .ToTable("Rules")
            .HasKey(r => r.Id);
        modelBuilder.Entity<Rule>()
            .Property(r => r.TypeRule)
            .IsRequired();
        modelBuilder.Entity<Rule>()
            .Property(r => r.Value)
            .HasColumnType("float")
            .IsRequired();
    }
}