using FinalExercise.Dal.Contracts.Repositories;
using FinalExercise.Entities;

namespace FinalExercise.Repositories.Contracts;

/// <summary>
/// Репозиторий работы с <see cref="Discipline"/>
/// </summary>
public interface IDisciplineRepository : IBaseWriteRepository<Discipline>
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
