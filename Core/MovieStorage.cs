using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Linq;
using System.Linq;

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
            PropertyNameCaseInsensitive = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping   // ← ЦЕ ГОЛОВНЕ
        };

        if (!string.IsNullOrEmpty(logFilePath))
        {
            _logWriter = new StreamWriter(logFilePath, true, System.Text.Encoding.UTF8);
            Log("=== MovieStorage запущено ===");
        }
    }

    public int Count => _movies.Count;   // ← Це було потрібно!

    public void AddMovie(Movie movie)
    {
        if (movie == null) throw new ArgumentNullException(nameof(movie));
        _movies.Add(movie);
        Log($"Додано фільм: {movie.Title}");
    }

    public List<Movie> GetMovies() => new(_movies);

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

        try
        {
            var json = File.ReadAllText(filePath);
            _movies = JsonSerializer.Deserialize<List<Movie>>(json, _jsonOptions)
                      ?? new List<Movie>();
            Log($"Завантажено {_movies.Count} фільмів з {filePath}");
        }
        catch (JsonException ex)
        {
            Log($"Помилка десеріалізації JSON: {ex.Message}");
            throw;
        }
    }

    public void ExportToXml(string filePath)
    {
        var doc = new XDocument(
            new XDeclaration("1.0", "utf-8", "yes"),
            new XElement("Movies",
                from m in _movies
                where m.AverageRating >= 8.0
                select new XElement("Movie",
                    new XElement("Id", m.Id),
                    new XElement("Title", m.Title),
                    new XElement("Director", m.Director),
                    new XElement("Genre", m.Genre),
                    new XElement("Rating", m.AverageRating),
                    new XElement("Budget", m.Budget)
                )
            )
        );

        doc.Save(filePath);
        Log($"Експортовано у XML: {filePath}");
    }

    private void Log(string message)
    {
        _logWriter?.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}");
        _logWriter?.Flush();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
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