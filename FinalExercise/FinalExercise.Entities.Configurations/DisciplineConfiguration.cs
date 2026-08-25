using FinalExercise.Context.EntityFrameworkCore;
using FinalExercise.Dal.Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalExercise.Entities.Configurations;

/// <summary>
/// Конфигурация сущности <see cref="Discipline"/> для Entity Framework Core
/// </summary>
public class DisciplineConfiguration: IEntityTypeConfiguration<Discipline>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Discipline> builder)
    {
        builder.ToTable("Disciplines");
        builder.HasIdAsKey();
        builder.CreateAuditConfiguration();
        builder.UpdateAuditConfiguration();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Description)
            .HasMaxLength(5000);

        builder.HasIndex(x => x.Name)
            .HasDatabaseName("IX_DisciplinesName")
            .IsUnique()
            .HasFilter($"\"{nameof(IEntityAuditDeletedAt.DeletedAt)}\" IS NULL");

        var seedDate = new DateTimeOffset(2026, 1, 1, 0, 0, 0, TimeSpan.Zero);

        builder.HasData(
            new Discipline
            {
                Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234567801"),
                Name = "Математика",
                Description = "Изучение чисел, структур, пространства и изменений",
                CreatedAt = seedDate, CreatedBy = "System",
                UpdatedAt = seedDate, UpdatedBy = "System"
            },
            new Discipline
            {
                Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234567802"),
                Name = "Физика",
                Description = "Наука о природе, изучающая фундаментальные законы Вселенной",
                CreatedAt = seedDate, CreatedBy = "System",
                UpdatedAt = seedDate, UpdatedBy = "System"
            },
            new Discipline
            {
                Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234567803"),
                Name = "Химия",
                Description = "Наука о веществах, их свойствах, строении и превращениях",
                CreatedAt = seedDate, CreatedBy = "System",
                UpdatedAt = seedDate, UpdatedBy = "System"
            },
            new Discipline
            {
                Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234567804"),
                Name = "Биология",
                Description = "Наука о живых организмах и их взаимодействии с окружающей средой",
                CreatedAt = seedDate, CreatedBy = "System",
                UpdatedAt = seedDate, UpdatedBy = "System"
            },
            new Discipline
            {
                Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234567805"),
                Name = "История",
                Description = "Наука о прошлом человечества, его развитии и ключевых событиях",
                CreatedAt = seedDate, CreatedBy = "System",
                UpdatedAt = seedDate, UpdatedBy = "System"
            },
            new Discipline
            {
                Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234567806"),
                Name = "Литература",
                Description = "Изучение художественных произведений и их анализа",
                CreatedAt = seedDate, CreatedBy = "System",
                UpdatedAt = seedDate, UpdatedBy = "System"
            },
            new Discipline
            {
                Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234567807"),
                Name = "Информатика",
                Description = "Наука об обработке информации с помощью компьютерных технологий",
                CreatedAt = seedDate, CreatedBy = "System",
                UpdatedAt = seedDate, UpdatedBy = "System"
            },
            new Discipline
            {
                Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234567808"),
                Name = "Английский язык",
                Description = "Изучение английского языка как иностранного",
                CreatedAt = seedDate, CreatedBy = "System",
                UpdatedAt = seedDate, UpdatedBy = "System"
            },
            new Discipline
            {
                Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234567809"),
                Name = "География",
                Description = "Наука о природе Земли, её населении и хозяйственной деятельности",
                CreatedAt = seedDate, CreatedBy = "System",
                UpdatedAt = seedDate, UpdatedBy = "System"
            },
            new Discipline
            {
                Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234567810"),
                Name = "Обществознание",
                Description = "Комплексная наука об обществе, его структуре и законах развития",
                CreatedAt = seedDate, CreatedBy = "System",
                UpdatedAt = seedDate, UpdatedBy = "System"
            },
            new Discipline
            {
                Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234567811"),
                Name = "Философия",
                Description = "Наука о наиболее общих законах развития природы, общества и мышления",
                CreatedAt = seedDate, CreatedBy = "System",
                UpdatedAt = seedDate, UpdatedBy = "System"
            },
            new Discipline
            {
                Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234567812"),
                Name = "Психология",
                Description = "Наука о психических процессах, состояниях и свойствах личности",
                CreatedAt = seedDate, CreatedBy = "System",
                UpdatedAt = seedDate, UpdatedBy = "System"
            },
            new Discipline
            {
                Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234567813"),
                Name = "Экономика",
                Description = "Наука об эффективном использовании ограниченных ресурсов",
                CreatedAt = seedDate, CreatedBy = "System",
                UpdatedAt = seedDate, UpdatedBy = "System"
            },
            new Discipline
            {
                Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234567814"),
                Name = "Правоведение",
                Description = "Наука о праве, нормативных актах и правоприменении",
                CreatedAt = seedDate, CreatedBy = "System",
                UpdatedAt = seedDate, UpdatedBy = "System"
            },
            new Discipline
            {
                Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234567815"),
                Name = "Музыка",
                Description = "Искусство организации звуков во времени для выражения эмоций и идей",
                CreatedAt = seedDate, CreatedBy = "System",
                UpdatedAt = seedDate, UpdatedBy = "System"
            },
            new Discipline
            {
                Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234567816"),
                Name = "Изобразительное искусство",
                Description = "Вид искусства, осуществляющий художественное познание действительности",
                CreatedAt = seedDate, CreatedBy = "System",
                UpdatedAt = seedDate, UpdatedBy = "System"
            },
            new Discipline
            {
                Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234567817"),
                Name = "Технология",
                Description = "Практическая деятельность человека по созданию объектов и систем",
                CreatedAt = seedDate, CreatedBy = "System",
                UpdatedAt = seedDate, UpdatedBy = "System"
            }
        );
    }
}
