using Ahatornn.TestGenerator;
using AutoMapper;
using FinalExercis.Repositories;
using FinalExercis.Services.Automapper;
using FinalExercis.Services.Contracts;
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

        disciplineService = new DisciplineService(repository, mapper);
    }

    /// <summary>
    ///
    /// </summary>
    [Fact]
    public async Task GetDisciplinesShouldReturnEmpty()
    {
        // Act
        var items = await disciplineService.GetDisciplinesAsync(CancellationToken.None);

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
        var items = await disciplineService.GetDisciplinesAsync(CancellationToken.None);

        // Assert
        items.Should()
            .NotBeNull()
            .And.HaveCount(2)
            .And.ContainSingle(x => x.Id == item1.Id)
            .And.ContainSingle(x => x.Id == item3.Id);
    }
}
