using AutoMapper;
using FinalExercis.Repositories.Contracts;
using FinalExercis.Services.Contracts;
using FinalExercis.Services.Contracts.Models;

namespace FinalExercis.Services;

public class DisciplineService : IDisciplineService
{
    private readonly IDisciplineRepository disciplineRepository;
    private readonly IMapper mapper;

    public DisciplineService(IDisciplineRepository disciplineRepository, IMapper mapper)
    {
        this.disciplineRepository = disciplineRepository;
        this.mapper = mapper;
    }

    async Task<IReadOnlyCollection<DisciplineModel>> IDisciplineService.GetDisciplinesAsync(CancellationToken cancellationToken)
    {
        var result = await disciplineRepository.GetDisciplinesAsync(cancellationToken);
        return mapper.Map<IReadOnlyCollection<DisciplineModel>>(result);
    }

    async Task<DisciplineModel?> IDisciplineService.GetDisciplineByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await disciplineRepository.GetDisciplineByIdAsync(id, cancellationToken);
        return mapper.Map<DisciplineModel>(result);
    }
}
