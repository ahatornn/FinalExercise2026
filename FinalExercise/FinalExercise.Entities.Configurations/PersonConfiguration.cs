using FinalExercise.Context.EntityFrameworkCore;
using FinalExercise.Dal.Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalExercise.Entities.Configurations;

/// <summary>
/// Конфигурация сущности <see cref="Person"/> для Entity Framework Core
/// </summary>
public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("People");
        builder.HasIdAsKey();
        builder.CreateAuditConfiguration();
        builder.UpdateAuditConfiguration();

        builder.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(x => x.Patronymic)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(x => x.LastName)
            .HasDatabaseName($"IX_{nameof(Person)}{nameof(Person.LastName)}")
            .IsUnique()
            .HasFilter($"\"{nameof(IEntityAuditDeletedAt.DeletedAt)}\" IS NULL");
    }
}
