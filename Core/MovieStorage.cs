using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;

namespace Core;

/// <summary>
/// Клас для збереження та завантаження колекції фільмів у JSON формат.
/// Демонструє серіалізацію/десеріалізацію та роботу з файловою системою.
/// </summary>
public class MovieStorage
{
    private List<Movie> _movies;
    private readonly JsonSerializerOptions _jsonOptions;

    public MovieStorage()
    {
        _movies = new List<Movie>();
        _jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };
    }

    /// <summary>
    /// Повертає список всіх фільмів.
    /// </summary>
    public List<Movie> GetMovies() => new(_movies);

    /// <summary>
    /// Додає фільм до зберіганого списку.
    /// </summary>
    public void AddMovie(Movie movie)
    {
        if (movie == null) throw new ArgumentNullException(nameof(movie));
        _movies.Add(movie);
    }

    /// <summary>
    /// Видаляє фільм зі списку за індексом.
    /// </summary>
    public bool RemoveMovieAt(int index)
    {
        if (index >= 0 && index < _movies.Count)
        {
            _movies.RemoveAt(index);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Очищує список фільмів.
    /// </summary>
    public void Clear() => _movies.Clear();

    /// <summary>
    /// Зберігає список фільмів у JSON файл за вказаним шляхом.
    /// </summary>
    public void SaveToJson(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
            throw new ArgumentException("Путь до файлу не може бути порожнім.", nameof(filePath));

        var json = JsonSerializer.Serialize(_movies, _jsonOptions);
        File.WriteAllText(filePath, json);
    }

    /// <summary>
    /// Завантажує список фільмів з JSON файлу.
    /// </summary>
    public void LoadFromJson(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
            throw new ArgumentException("Путь до файлу не може бути порожнім.", nameof(filePath));

        if (!File.Exists(filePath))
            throw new FileNotFoundException($"Файл не знайдено: {filePath}");

        var json = File.ReadAllText(filePath);
        _movies = JsonSerializer.Deserialize<List<Movie>>(json, _jsonOptions) ?? new List<Movie>();
    }

    /// <summary>
    /// Повертає кількість фільмів.
    /// </summary>
    public int Count => _movies.Count;
}
