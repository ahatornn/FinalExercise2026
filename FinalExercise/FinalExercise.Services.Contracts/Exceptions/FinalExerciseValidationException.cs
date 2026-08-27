using FinalExercise.Common;

namespace FinalExercise.Services.Contracts.Exceptions;

public class FinalExerciseValidationException : FinalExerciseException
{
    /// <summary>
    /// Ошибки
    /// </summary>
    public IEnumerable<InvalidateItemModel> Errors { get; }

    public FinalExerciseValidationException(IEnumerable<InvalidateItemModel> errors)
    {
        Errors = errors;
    }
}
