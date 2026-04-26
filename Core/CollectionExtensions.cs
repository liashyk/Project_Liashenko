using System;
using System.Collections.Generic;
using System.Linq;

namespace Core;

/// <summary>
/// Корисні методи розширення для колекцій і базових типів, що використовуються
/// у проєкті "Каталог фільмів".
/// </summary>
public static class CollectionExtensions
{
    /// <summary>
    /// Форматує бюджет у зручний для читання рядок:
    /// - якщо >= 1_000_000 → "$XXX.YY млн",
    /// - якщо >= 1_000 → "$XXX тис.",
    /// - інакше → "$N".
    /// </summary>
    public static string ToBudgetString(this double budget)
    {
        if (budget >= 1_000_000)
            return $"${budget / 1_000_000:F2} млн";
        if (budget >= 1_000)
            return $"${budget / 1_000:F0} тис.";
        return $"${budget:N0}";
    }

    /// <summary>
    /// Повертає кількість слів у рядку. Слова вважаються розділеними білими пропусками.
    /// Порожній або null рядок — 0.
    /// </summary>
    public static int WordCount(this string? s)
    {
        if (string.IsNullOrWhiteSpace(s))
            return 0;
        var parts = s!.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
        return parts.Length;
    }

    /// <summary>
    /// Обчислює середній рейтинг колекції фільмів. Якщо колекція порожня — повертає 0.0.
    /// </summary>
    public static double AverageRating(this IEnumerable<Movie> movies)
    {
        if (movies == null)
            throw new ArgumentNullException(nameof(movies));
        if (!movies.Any())
            return 0.0;
        return movies.Average(m => m.AverageRating);
    }
}
