namespace FinalExercis.Services.Contracts.Models;

/// <summary>
/// Модель предмета
/// </summary>
public class DisciplineModel : DisciplineCreateModel
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }
}
