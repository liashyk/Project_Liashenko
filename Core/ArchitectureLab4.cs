using System;
using System.Collections.Generic;

namespace Core;

/// <summary>
/// Абстрактний базовий клас CatalogItem — демонстрація абстракції.
/// Містить virtual метод Summary та abstract метод GetDetails.
/// </summary>
public abstract class CatalogItem
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Віртуальний метод з базовою реалізацією.
    /// </summary>
    public virtual string Summary() => $"[{Id}] {Title}";

    /// <summary>
    /// Абстрактний метод, що вимагає реалізації в нащадках.
    /// </summary>
    public abstract string GetDetails();
}

/// <summary>
/// Інтерфейс для показу інформації — демонстрація інтерфейсів.
/// </summary>
public interface IShow
{
    void ShowInfo();
}

/// <summary>
/// Клас MovieItem — наслідує CatalogItem та реалізує IShow.
/// </summary>
public class MovieItem : CatalogItem, IShow
{
    public string Director { get; set; } = string.Empty;
    public double AverageRating { get; set; }
    public double Budget { get; set; }

    public override string Summary() => $"[ФІЛЬМ #{Id}] {Title} — реж. {Director}";

    public override string GetDetails() => $"Назва: {Title}\nРежисер: {Director}\nРейтинг: {AverageRating:F1}\nБюджет: ${Budget:N0}";

    public void ShowInfo() => Console.WriteLine(Summary());
}

/// <summary>
/// Клас ActorItem — наслідує CatalogItem та реалізує IShow.
/// </summary>
public class ActorItem : CatalogItem, IShow
{
    public string FullName { get; set; } = string.Empty;
    public int MoviesCount { get; set; }

    // Переозначаємо Summary
    public override string Summary() => $"[АКТОР #{Id}] {FullName}";

    public override string GetDetails() => $"Ім'я: {FullName}\nФільмів: {MoviesCount}";

    public void ShowInfo() => Console.WriteLine(Summary());
}

/// <summary>
/// PlaybackSession — приклад композиції, об'єкт створюється і управляється контролером.
/// </summary>
public sealed class PlaybackSession : IDisposable
{
    private bool _running;
    public PlaybackSession() => _running = false;

    public void Start(CatalogItem item)
    {
        _running = true;
        Console.WriteLine($"    [Session] Почато відтворення: {item.Title}");
    }

    public void Stop()
    {
        if (_running)
        {
            _running = false;
            Console.WriteLine("    [Session] Зупинено відтворення.");
        }
    }

    public void Dispose() => Stop();
}

/// <summary>
/// Контролер, що створює і володіє PlaybackSession — приклад композиції.
/// </summary>
public class PlaybackController
{
    private readonly PlaybackSession _session;
    public PlaybackController()
    {
        // композиція: контролер створює і володіє сесією
        _session = new PlaybackSession();
    }

    public void Play(CatalogItem item)
    {
        Console.WriteLine($"  [Controller] Готуємось відтворити: {item.Title}");
        _session.Start(item);
    }

    public void Stop() => _session.Stop();
}

/// <summary>
/// CatalogContainer — приклад агрегації: контейнер приймає об'єкти, створені зовні.
/// </summary>
public class CatalogContainer
{
    private readonly List<CatalogItem> _items;
    public CatalogContainer(IEnumerable<CatalogItem> items)
    {
        _items = new List<CatalogItem>(items);
    }

    public int Count => _items.Count;
    public IEnumerable<CatalogItem> Items => _items;
    public void Add(CatalogItem item) => _items.Add(item);
}
