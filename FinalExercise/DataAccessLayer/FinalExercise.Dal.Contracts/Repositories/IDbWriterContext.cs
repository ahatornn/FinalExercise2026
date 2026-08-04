using FinalExercis.Common;

namespace FinalExercise.Dal.Contracts.Repositories;

/// <summary>
/// Определяет контекст репозитория записи сущностей
/// </summary>
public interface IDbWriterContext
{
    /// <inheritdoc cref="IWriter"/>
    IWriter Writer { get; }

    /// <inheritdoc cref="IDateTimeProvider"/>
    IDateTimeProvider DateTimeProvider { get; }

    /// <inheritdoc cref="IIdentityProvider"/>
    IIdentityProvider IdentityProvider { get; }
}
