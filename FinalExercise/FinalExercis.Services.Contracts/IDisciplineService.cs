using FinalExercis.Services.Contracts.Models;

namespace FinalExercis.Services.Contracts;

public interface IDisciplineService
{
    /// <summary>
    ///
    /// </summary>
    Task<IReadOnlyCollection<DisciplineModel>> GetDisciplinesAsync(CancellationToken cancellationToken);

    /// <summary>
    ///
    /// </summary>
    Task<DisciplineModel?> GetDisciplineByIdAsync(Guid id, CancellationToken cancellationToken);
}
