using FinalExercise.Entities;

namespace FinalExercis.Repositories.Contracts;

/// <summary>
/// Репозиторий работы с <see cref="Discipline"/>
/// </summary>
public interface IDisciplineRepository
{
    /// <summary>
    ///
    /// </summary>
    Task<IReadOnlyCollection<Discipline>> GetDisciplinesAsync(CancellationToken cancellationToken);

    /// <summary>
    ///
    /// </summary>
    Task<Discipline?> GetDisciplineByIdAsync(Guid id, CancellationToken cancellationToken);
}
