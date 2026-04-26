using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Core;

/// <summary>
/// Клас-контейнер для колекції фільмів. Агрегує внутрішній List<Movie> і надає
/// зручні операції доступу та пошуку.
/// </summary>
public class MovieCollection : IEnumerable<Movie>
{
    private readonly List<Movie> _movies = new();
    private readonly Dictionary<int, Movie> _moviesById = new();
    private readonly HashSet<string> _genres = new(StringComparer.OrdinalIgnoreCase);

    /// <summary>
    /// Додає фільм до колекції. Якщо Id вже існує — кидає ArgumentException.
    /// </summary>
    public void Add(Movie m)
    {
        if (m == null) throw new ArgumentNullException(nameof(m));
        if (_moviesById.ContainsKey(m.Id))
            throw new ArgumentException($"Фільм з Id={m.Id} вже існує в колекції.");
        _movies.Add(m);
        _moviesById[m.Id] = m;
        if (!string.IsNullOrWhiteSpace(m.Genre))
            _genres.Add(m.Genre);
    }

    /// <summary>
    /// Кількість фільмів у колекції.
    /// </summary>
    public int Count => _movies.Count;

    /// <summary>
    /// Повертає фільм за Id або null, якщо не знайдено. O(1).
    /// </summary>
    public Movie? GetById(int id)
    {
        return _moviesById.TryGetValue(id, out var m) ? m : null;
    }

    /// <summary>
    /// Повертає фільми з рейтингом не менше за minRating, використовуючи LINQ над _moviesById.Values.
    /// </summary>
    public IEnumerable<Movie> GetHighRatedMovies(double minRating = 8.5)
    {
        return _moviesById.Values.Where(m => m.AverageRating >= minRating);
    }

    /// <summary>
    /// Надає ітератор для foreach. Використовує yield return — демонстрація простого протоколу ітерації.
    /// Це також ілюструє duck-typing: реалізації IEnumerable<Movie> вистачає для використання в foreach.
    /// </summary>
    public IEnumerator<Movie> GetEnumerator()
    {
        foreach (var m in _movies)
            yield return m; // повертаємо елементи послідовно
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    /// <summary>
    /// Повертає копію множини жанрів (щоб зовнішній код не міг модифікувати внутрішню структуру).
    /// </summary>
    public HashSet<string> Genres => new(_genres, StringComparer.OrdinalIgnoreCase);

    /// <summary>
    /// Демонстраційний метод: додає жан явно (показати, що дубль не додається).
    /// </summary>
    public bool AddGenre(string genre) => _genres.Add(genre);

    /// <summary>
    /// Повертає внутрішній HashSet (для демонстрації операцій IntersectWith/UnionWith у Program).
    /// Повертає копію для безпеки.
    /// </summary>
    public HashSet<string> GetGenresSet() => new(_genres, StringComparer.OrdinalIgnoreCase);
}
