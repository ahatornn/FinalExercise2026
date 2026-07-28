using FinalExercis.Repositories.Contracts;
using FinalExercise.Context.Repositories;
using FinalExercise.Dal.Contracts.Repositories;
using FinalExercise.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinalExercis.Repositories;

public class DisciplineRepository : IDisciplineRepository
{
    private readonly IReader reader;

    /// <summary>
    /// ctor.
    /// </summary>
    public DisciplineRepository(IReader reader)
    {
        this.reader = reader;
    }

    Task<IReadOnlyCollection<Discipline>> IDisciplineRepository.GetDisciplinesAsync(CancellationToken cancellationToken)
        => reader.Read<Discipline>()
            .NotDeletedAt()
            .OrderBy(x => x.Name)
            .ToReadOnlyCollectionAsync(cancellationToken);

    Task<Discipline?> IDisciplineRepository.GetDisciplineByIdAsync(Guid id, CancellationToken cancellationToken)
        => reader.Read<Discipline>()
            .NotDeletedAt()
            .ById(id)
            .FirstOrDefaultAsync(cancellationToken);
}
