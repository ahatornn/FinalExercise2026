using FinalExercise.Common;

namespace FinalExercise.Api.Implementations;

public class DateTimeProvider : IDateTimeProvider
{

    DateTimeOffset IDateTimeProvider.UtcNow => DateTimeOffset.UtcNow;

    DateTime IDateTimeProvider.LocalNow => DateTime.Now;
}
