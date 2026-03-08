namespace Core;

/// <summary>
/// Клас, що описує актора або членів знімальної групи.
/// </summary>
public class Actor
{
    /// <summary>Унікальний ідентифікатор актора.</summary>
    public int Id { get; set; }

    /// <summary>Повне ім'я актора.</summary>
    public string FullName { get; set; } = string.Empty;

    /// <summary>Країна походження актора.</summary>
    public string Nationality { get; set; } = string.Empty;

    /// <summary>Дата народження актора.</summary>
    public DateTime DateOfBirth { get; set; }

    /// <summary>Кількість знятих фільмів у кар'єрі.</summary>
    public int MoviesCount { get; set; }

    /// <summary>Середній рейтинг фільмів актора.</summary>
    public double AverageMovieRating { get; set; }

    /// <summary>Чи є актор лауреатом премії Оскар.</summary>
    public bool IsOscarWinner { get; set; }

    /// <summary>Гонорар актора за фільм у доларах США.</summary>
    public double FeePerMovie { get; set; }

    /// <summary>
    /// Обчислює вік актора.
    /// </summary>
    public int Age => DateTime.Today.Year - DateOfBirth.Year -
                      (DateTime.Today < DateOfBirth.AddYears(DateTime.Today.Year - DateOfBirth.Year) ? 1 : 0);

    /// <summary>
    /// Повертає рядковий опис актора.
    /// </summary>
    public override string ToString()
    {
        return $"[АКТОР #{Id}]\n" +
               $"  Ім'я:         {FullName}\n" +
               $"  Країна:       {Nationality}\n" +
               $"  Дата нар.:    {DateOfBirth:dd.MM.yyyy} (вік: {Age})\n" +
               $"  Фільмів:      {MoviesCount}\n" +
               $"  Сер. рейтинг: {AverageMovieRating:F1} / 10\n" +
               $"  Оскар:        {(IsOscarWinner ? "Так 🏆" : "Ні")}\n" +
               $"  Гонорар:      ${FeePerMovie:N0} / фільм";
    }
}
