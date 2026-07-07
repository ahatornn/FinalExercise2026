using FinalExercise.Context.EntityFrameworkCore;
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
            .IsUnique();
    }
}
