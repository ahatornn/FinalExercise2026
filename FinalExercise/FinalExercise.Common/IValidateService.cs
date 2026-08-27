using FluentValidation.Results;

namespace FinalExercise.Common;

/// <summary>
/// Сервис валидации
/// </summary>
public interface IValidateService
{
    /// <summary>
    /// Валидация модели
    /// </summary>
    Task ValidateAsync<TModel>(TModel model, CancellationToken cancellationToken)
        where TModel : class;
}
