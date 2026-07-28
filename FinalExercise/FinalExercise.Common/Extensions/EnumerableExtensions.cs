using System.Collections.ObjectModel;

namespace FinalExercise.Common.Extensions;

/// <summary>
/// Методы расширения для IEnumerable
/// </summary>
public static class EnumerableExtensions
{
    /// <summary>
    /// Преобразует IEnumerable в readonly коллекцию.
    /// </summary>
    /// <param name="source">Исходная коллекция</param>
    /// <typeparam name="T">Тип элементов</typeparam>
    public static ReadOnlyCollection<T> ToReadOnlyCollection<T>(this IEnumerable<T> source)
    {
        var list = source as IList<T> ?? source.ToList();
        return new ReadOnlyCollection<T>(list);
    }
}
