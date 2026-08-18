using Ahatornn.TestGenerator;
using AutoMapper;
using FinalExercis.Repositories;
using FinalExercis.Services.Automapper;
using FinalExercis.Services.Contracts;
using FinalExercis.Services.Contracts.Exceptions;
using FinalExercis.Services.Contracts.Models;
using FinalExercise.Context.Tests;
using FinalExercise.Entities;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace FinalExercis.Services.Tests;

public class DisciplineServiceTests : FinalExerciseContextInMemory
{
    private readonly IDisciplineService disciplineService;

    /// <summary>
    /// ctor.
    /// </summary>
    public DisciplineServiceTests()
    {
        var repository = new DisciplineRepository(WriterContext, Context);

        var profile = new ServiceProfile();
        var mapper = new MapperConfiguration(x => x.AddProfile(profile), NullLoggerFactory.Instance).CreateMapper();

        disciplineService = new DisciplineService(repository, Context, mapper);
    }

    /// <summary>
    ///
    /// </summary>
    [Fact]
    public async Task GetDisciplinesShouldReturnEmpty()
    {
        // Act
        var items = await disciplineService.GetDisciplines(CancellationToken.None);

        // Assert
        items.Should().NotBeNull().And.BeEmpty();
    }

    /// <summary>
    ///
    /// </summary>
    [Fact]
    public async Task GetDisciplinesShouldReturnValue()
    {
        // Arrange
        var item1 = TestEntityProvider.Shared.Create<Discipline>(x => x.Name = "Якорь");
        var item2 = TestEntityProvider.Shared.Create<Discipline>(x => x.DeletedAt = DateTimeOffset.Now);
        var item3 = TestEntityProvider.Shared.Create<Discipline>(x => x.Name = "Арбуз");
        Context.AddRange(item1, item2, item3);
        await UnitOfWork.SaveChangesAsync(CancellationToken.None);

        // Act
        var items = await disciplineService.GetDisciplines(CancellationToken.None);

        // Assert
        items.Should()
            .NotBeNull()
            .And.HaveCount(2)
            .And.ContainSingle(x => x.Id == item1.Id)
            .And.ContainSingle(x => x.Id == item3.Id);
    }

    [Fact]
    public async Task CreateDisciplineShouldWork()
    {
        // Arrange
        var createModel = TestEntityProvider.Shared.Create<DisciplineCreateModel>();

        // Act
        await disciplineService.CreateDiscipline(createModel, CancellationToken.None);

        // Assert
        Context.Set<Discipline>().Should().BeEquivalentTo([new
        {
            Name = createModel.Name,
            Description = createModel.Description
        }]);
    }

    [Fact]
    public async Task UpdateDisciplineShouldWork()
    {
        // Arrange
        var entity = TestEntityProvider.Shared.Create<Discipline>();
        Context.Add(entity);
        await UnitOfWork.SaveChangesAsync(CancellationToken.None);

        var updateModel = TestEntityProvider.Shared.Create<DisciplineModel>(x => x.Id = entity.Id);

        // Act
        await disciplineService.UpdateDiscipline(updateModel, CancellationToken.None);

        // Assert
        Context.Set<Discipline>().Should().BeEquivalentTo([new
        {
            Name = updateModel.Name,
            Description = updateModel.Description
        }]);
    }

    [Fact]
    public async Task UpdateDisciplineShouldThrowNotFoundException()
    {
        // Arrange
        var entity = TestEntityProvider.Shared.Create<Discipline>();
        Context.Add(entity);
        await UnitOfWork.SaveChangesAsync(CancellationToken.None);

        var updateModel = TestEntityProvider.Shared.Create<DisciplineModel>(x => x.Id = Guid.NewGuid());

        // Act
        var act = () => disciplineService.UpdateDiscipline(updateModel, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<EntityNotFoundException<Discipline>>();
    }

    [Fact]
    public async Task DeleteDisciplineShouldWork()
    {
        // Arrange
        var entity = TestEntityProvider.Shared.Create<Discipline>();
        Context.Add(entity);
        await UnitOfWork.SaveChangesAsync(CancellationToken.None);

        // Act
        await disciplineService.DeleteDiscipline(entity.Id, CancellationToken.None);

        // Assert
        Context.Set<Discipline>().FirstOrDefault()?.DeletedAt.Should().NotBeNull();
    }

    [Fact]
    public async Task DeleteDisciplineShouldThrowNotFoundException()
    {
        // Arrange
        var entity = TestEntityProvider.Shared.Create<Discipline>();
        Context.Add(entity);
        await UnitOfWork.SaveChangesAsync(CancellationToken.None);

        // Act
        var act = () => disciplineService.DeleteDiscipline(Guid.NewGuid(), CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<EntityNotFoundException<Discipline>>();
    }
}
