using FinalExercise.Services.Contracts.Models;

namespace FinalExercise.Services.Contracts;

public interface IDisciplineService
{
    /// <summary>
    ///
    /// </summary>
    Task<IReadOnlyCollection<DisciplineModel>> GetDisciplines(CancellationToken cancellationToken);

    /// <summary>
    ///
    /// </summary>
    Task<DisciplineModel> GetDisciplineById(Guid id, CancellationToken cancellationToken);

    /// <summary>
    ///
    /// </summary>
    Task CreateDiscipline(DisciplineCreateModel disciplineCreateModel, CancellationToken cancellationToken);

    /// <summary>
    ///
    /// </summary>
    Task UpdateDiscipline(DisciplineModel disciplineModel, CancellationToken cancellationToken);

    /// <summary>
    ///
    /// </summary>
    Task DeleteDiscipline(Guid id, CancellationToken cancellationToken);
}
