using FinalExercise.Dal.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace FinalExercise.Context.Tests;

/// <summary>
/// Контекст <see cref="FinalExerciseContext"/> для тестов с базой в памяти. Один контекст на тест.
/// </summary>
public class FinalExerciseContextInMemory: IAsyncDisposable
{
    /// <summary>
    /// Контекст <see cref="FinalExerciseContext"/>
    /// </summary>
    protected FinalExerciseContext Context { get; }

    /// <inheritdoc cref="IUnitOfWork"/>
    protected IUnitOfWork UnitOfWork => Context;

    /// <inheritdoc cref="IDbWriterContext"/>
    protected IDbWriterContext WriterContext => new TestWriterContext(Context);

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="FinalExerciseContextInMemory"/>
    /// </summary>
    protected FinalExerciseContextInMemory()
    {
        var optionsBuilder = new DbContextOptionsBuilder<FinalExerciseContext>()
            .UseInMemoryDatabase($"FinalExerciseContextTests{Guid.NewGuid()}")
            .ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning));
        Context = new FinalExerciseContext(optionsBuilder.Options);
    }

    /// <inheritdoc cref="IAsyncDisposable"/>
    public async ValueTask DisposeAsync()
    {
        await Context.Database.EnsureDeletedAsync();
        await Context.DisposeAsync();
    }
}
