namespace Core;

/// <summary>
/// Клас, що описує фільм у каталозі.
/// </summary>
public class Movie
{
    /// <summary>Унікальний ідентифікатор фільму.</summary>
    public int Id { get; set; }

    /// <summary>Назва фільму.</summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>Режисер фільму.</summary>
    public string Director { get; set; } = string.Empty;

    /// <summary>Жанр фільму.</summary>
    public string Genre { get; set; } = string.Empty;

    /// <summary>Дата виходу фільму.</summary>
    public DateTime ReleaseDate { get; set; }

    /// <summary>Тривалість фільму в хвилинах.</summary>
    public int DurationMinutes { get; set; }

    /// <summary>Середній рейтинг фільму (0.0 - 10.0).</summary>
    public double AverageRating { get; set; }

    /// <summary>Чи доступний фільм для перегляду онлайн.</summary>
    public bool IsAvailableOnline { get; set; }

    /// <summary>Бюджет фільму в доларах США.</summary>
    public double Budget { get; set; }

    /// <summary>
    /// Повертає рядковий опис фільму.
    /// </summary>
    public override string ToString()
    {
        return $"[ФІЛЬМ #{Id}]\n" +
               $"  Назва:        {Title}\n" +
               $"  Режисер:      {Director}\n" +
               $"  Жанр:         {Genre}\n" +
               $"  Рік виходу:   {ReleaseDate:dd.MM.yyyy}\n" +
               $"  Тривалість:   {DurationMinutes} хв.\n" +
               $"  Рейтинг:      {AverageRating:F1} / 10\n" +
               $"  Онлайн:       {(IsAvailableOnline ? "Так" : "Ні")}\n" +
               $"  Бюджет:       ${Budget:N0}";
    }
}
