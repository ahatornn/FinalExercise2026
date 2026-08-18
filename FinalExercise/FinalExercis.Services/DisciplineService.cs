using AutoMapper;
using FinalExercis.Repositories.Contracts;
using FinalExercis.Services.Contracts;
using FinalExercis.Services.Contracts.Exceptions;
using FinalExercis.Services.Contracts.Models;
using FinalExercise.Dal.Contracts.Repositories;
using FinalExercise.Entities;

namespace FinalExercis.Services;

public class DisciplineService : IDisciplineService
{
    private readonly IDisciplineRepository disciplineRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public DisciplineService(IDisciplineRepository disciplineRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.disciplineRepository = disciplineRepository;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    async Task<IReadOnlyCollection<DisciplineModel>> IDisciplineService.GetDisciplines(CancellationToken cancellationToken)
    {
        var result = await disciplineRepository.GetDisciplinesAsync(cancellationToken);
        return mapper.Map<IReadOnlyCollection<DisciplineModel>>(result);
    }

    async Task<DisciplineModel> IDisciplineService.GetDisciplineById(Guid id, CancellationToken cancellationToken)
    {
        var result = await disciplineRepository.GetDisciplineByIdAsync(id, cancellationToken);
        if (result is null)
        {
            throw new EntityNotFoundException<Discipline>(id);
        }
        return mapper.Map<DisciplineModel>(result);
    }

    async Task IDisciplineService.CreateDiscipline(DisciplineCreateModel disciplineCreateModel, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Discipline>(disciplineCreateModel);
        disciplineRepository.Add(entity);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    async Task IDisciplineService.UpdateDiscipline(DisciplineModel disciplineModel, CancellationToken cancellationToken)
    {
        var entity = await disciplineRepository.GetDisciplineByIdAsync(disciplineModel.Id, cancellationToken);
        if (entity is null)
        {
            throw new EntityNotFoundException<Discipline>(disciplineModel.Id);
        }

        mapper.Map(disciplineModel, entity);
        disciplineRepository.Update(entity);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    async Task IDisciplineService.DeleteDiscipline(Guid id, CancellationToken cancellationToken)
    {
        var entity = await disciplineRepository.GetDisciplineByIdAsync(id, cancellationToken);
        if (entity is null)
        {
            throw new EntityNotFoundException<Discipline>(id);
        }

        disciplineRepository.Delete(entity);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
