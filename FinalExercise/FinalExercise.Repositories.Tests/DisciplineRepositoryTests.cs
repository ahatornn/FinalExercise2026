using Ahatornn.TestGenerator;
using FinalExercise.Repositories.Contracts;
using FinalExercise.Context.Tests;
using FinalExercise.Entities;
using FluentAssertions;
using Xunit;

namespace FinalExercise.Repositories.Tests;

/// <summary>
/// Тесты для <see cref="DisciplineRepository"/>
/// </summary>
public class DisciplineRepositoryTests : FinalExerciseContextInMemory
{
    private readonly IDisciplineRepository repository;

    /// <summary>
    /// ctor.
    /// </summary>
    public DisciplineRepositoryTests()
    {
        repository = new DisciplineRepository(WriterContext, Context);
    }

    /// <summary>
    ///
    /// </summary>
    [Fact]
    public async Task GetDisciplinesShouldReturnEmpty()
    {
        // Act
        var items = await repository.GetDisciplinesAsync(CancellationToken.None);

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
        var items = await repository.GetDisciplinesAsync(CancellationToken.None);

        // Assert
        items.Should()
            .NotBeNull()
            .And.HaveCount(2)
            .And.ContainSingle(x => x.Id == item1.Id)
            .And.ContainSingle(x => x.Id == item3.Id);
    }
}
