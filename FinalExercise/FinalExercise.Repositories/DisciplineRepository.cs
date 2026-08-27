using FinalExercise.Repositories.Contracts;
using FinalExercise.Context.Repositories;
using FinalExercise.Dal.Contracts.Repositories;
using FinalExercise.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinalExercise.Repositories;

public class DisciplineRepository : BaseWriteRepository<Discipline>,  IDisciplineRepository
{
    private readonly IReader reader;

    /// <summary>
    /// ctor.
    /// </summary>
    public DisciplineRepository(IDbWriterContext writerContext, IReader reader)
    : base(writerContext)
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
