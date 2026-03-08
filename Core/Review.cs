namespace Core;

/// <summary>
/// Клас, що описує відгук користувача на фільм.
/// </summary>
public class Review
{
    /// <summary>Унікальний ідентифікатор відгуку.</summary>
    public int Id { get; set; }

    /// <summary>Ідентифікатор фільму, до якого належить відгук.</summary>
    public int MovieId { get; set; }

    /// <summary>Ім'я автора відгуку.</summary>
    public string AuthorName { get; set; } = string.Empty;

    /// <summary>Текст відгуку.</summary>
    public string Text { get; set; } = string.Empty;

    /// <summary>Оцінка фільму від користувача (1.0 - 10.0).</summary>
    public double Rating { get; set; }

    /// <summary>Дата публікації відгуку.</summary>
    public DateTime PublishedAt { get; set; }

    /// <summary>Чи рекомендує автор переглянути фільм.</summary>
    public bool IsRecommended { get; set; }

    /// <summary>Кількість лайків відгуку від інших користувачів.</summary>
    public int LikesCount { get; set; }

    /// <summary>
    /// Повертає рядковий опис відгуку.
    /// </summary>
    public override string ToString()
    {
        return $"[ВІДГУК #{Id} → Фільм #{MovieId}]\n" +
               $"  Автор:        {AuthorName}\n" +
               $"  Оцінка:       {Rating:F1} / 10\n" +
               $"  Рекомендує:   {(IsRecommended ? "Так ✓" : "Ні ✗")}\n" +
               $"  Дата:         {PublishedAt:dd.MM.yyyy}\n" +
               $"  Лайки:        {LikesCount}\n" +
               $"  Текст:        \"{Text}\"";
    }
}
