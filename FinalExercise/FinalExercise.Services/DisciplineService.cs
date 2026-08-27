using AutoMapper;
using FinalExercise.Repositories.Contracts;
using FinalExercise.Services.Contracts;
using FinalExercise.Services.Contracts.Exceptions;
using FinalExercise.Services.Contracts.Models;
using FinalExercise.Dal.Contracts.Repositories;
using FinalExercise.Entities;

namespace FinalExercise.Services;

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

    async Task<DisciplineModel> IDisciplineService.CreateDiscipline(DisciplineCreateModel disciplineCreateModel, CancellationToken cancellationToken)
    {
        var existing = await disciplineRepository.GetByName(disciplineCreateModel.Name, cancellationToken);
        if (existing is not null)
        {
            throw new FinalExerciseInvalidOperationException("Предмет с таким названием уже существует");
        }

        var entity = mapper.Map<Discipline>(disciplineCreateModel);
        disciplineRepository.Add(entity);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        var result = mapper.Map<DisciplineModel>(entity);
        return result;
    }

    async Task IDisciplineService.UpdateDiscipline(DisciplineModel disciplineModel, CancellationToken cancellationToken)
    {
        var existing = await disciplineRepository.GetByName(disciplineModel.Name, cancellationToken);
        if (existing is not null && existing.Id != disciplineModel.Id)
        {
            throw new FinalExerciseInvalidOperationException("Предмет с таким названием уже существует");
        }

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
