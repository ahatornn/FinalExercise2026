namespace FinalExercis.Services.Contracts.Exceptions;

public class EntityNotFoundException<T>(Guid id) : FinalExerciseException($"Сущность '{typeof(T).Name}' с идентификатором '{id}' не найдена");
