using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Linq;
using System.Linq;
using System.Text.Encodings.Web;

namespace Core;

public class MovieStorage : IDisposable
{
    private List<Movie> _movies = new();
    private readonly JsonSerializerOptions _jsonOptions;
    private StreamWriter? _logWriter;
    private bool _disposed = false;

    public MovieStorage(string? logFilePath = null)
    {
        _jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };

        if (!string.IsNullOrEmpty(logFilePath))
        {
            _logWriter = new StreamWriter(logFilePath, true, System.Text.Encoding.UTF8);
            Log("=== MovieStorage запущено ===");
        }
    }

    /// <summary>
    /// Повертає список всіх фільмів.
    /// </summary>
    public List<Movie> GetMovies() => new(_movies);

    public void AddMovie(Movie movie)
    {
        if (movie == null) throw new ArgumentNullException(nameof(movie));
        _movies.Add(movie);
        Log($"Додано фільм: {movie.Title}");
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
            throw new ArgumentException("Шлях до файлу не може бути порожнім.");

        var json = JsonSerializer.Serialize(_movies, _jsonOptions);
        File.WriteAllText(filePath, json);
        Log($"Збережено {_movies.Count} фільмів у {filePath}");
    }

    public void LoadFromJson(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException($"Файл не знайдено: {filePath}");

        var json = File.ReadAllText(filePath);
        _movies = JsonSerializer.Deserialize<List<Movie>>(json, _jsonOptions) ?? new List<Movie>();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;

        if (disposing && _logWriter != null)
        {
            Log("=== MovieStorage завершив роботу ===");
            _logWriter.Dispose();
            _logWriter = null;
        }
        _disposed = true;
    }
}