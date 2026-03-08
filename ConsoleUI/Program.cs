using Core;

// ╔══════════════════════════════════════════════════════════════╗
// ║       Лабораторна робота №1 — Каталог фільмів               ║
// ║       Тема 21: Каталог фільмів з рейтингами                 ║
// ║       Пошук, відгуки, рейтинги                              ║
// ╚══════════════════════════════════════════════════════════════╝

Console.OutputEncoding = System.Text.Encoding.UTF8;

PrintSeparator('═', 60);
Console.WriteLine("  КАТАЛОГ ФІЛЬМІВ — Лабораторна робота №1");
PrintSeparator('═', 60);

// ─────────────────────────────────────────────────────────────
// ЗАГАЛЬНЕ ЗАВДАННЯ: Інформація про систему (System.Environment)
// ─────────────────────────────────────────────────────────────
Console.WriteLine("\n📋 СИСТЕМНА ІНФОРМАЦІЯ\n");

Console.WriteLine($"  ОС:                   {System.Environment.OSVersion}");
Console.WriteLine($"  Платформа:            {System.Environment.OSVersion.Platform}");
Console.WriteLine($"  64-бітна ОС:          {System.Environment.Is64BitOperatingSystem}");
Console.WriteLine($"  Версія .NET:          {System.Environment.Version}");
Console.WriteLine($"  Ім'я машини:          {System.Environment.MachineName}");
Console.WriteLine($"  Кількість процесорів: {System.Environment.ProcessorCount}");

// Оперативна пам'ять через System.GC
long memoryUsed = System.GC.GetTotalMemory(forceFullCollection: false);
Console.WriteLine($"\n  💾 ПАМ'ЯТЬ ДОДАТКУ (System.GC):");
Console.WriteLine($"  Використовується:     {memoryUsed:N0} байт");
Console.WriteLine($"  Використовується:     {memoryUsed / 1024.0:F2} КБ");
Console.WriteLine($"  Використовується:     {memoryUsed / 1024.0 / 1024.0:F4} МБ");
Console.WriteLine($"  Покоління GC (макс.): {System.GC.MaxGeneration}");

// ─────────────────────────────────────────────────────────────
// ІНДИВІДУАЛЬНЕ ЗАВДАННЯ: Класи предметної області
// ─────────────────────────────────────────────────────────────

PrintSeparator('─', 60);
Console.WriteLine("\n🎬 КАТАЛОГ ФІЛЬМІВ — Тестові об'єкти\n");

// ──────────────────────────────────────
// Об'єкт класу Movie (Фільм)
// ──────────────────────────────────────
Movie movie = new Movie
{
    Id             = 1,
    Title          = "Початок (Inception)",
    Director       = "Крістофер Нолан",
    Genre          = "Науково-фантастичний трилер",
    ReleaseDate    = new DateTime(2010, 7, 16),
    DurationMinutes = 148,
    AverageRating  = 8.8,
    IsAvailableOnline = true,
    Budget         = 160_000_000
};

Console.WriteLine(movie);
PrintSeparator('·', 60);

// ──────────────────────────────────────
// Об'єкт класу Review (Відгук)
// ──────────────────────────────────────
Review review = new Review
{
    Id            = 101,
    MovieId       = 1,
    AuthorName    = "Олена Коваленко",
    Text          = "Неймовірний фільм! Змусив думати ще кілька днів після перегляду.",
    Rating        = 9.5,
    PublishedAt   = new DateTime(2024, 3, 15),
    IsRecommended = true,
    LikesCount    = 342
};

Console.WriteLine(review);
PrintSeparator('·', 60);

// ──────────────────────────────────────
// Об'єкт класу Actor (Актор)
// ──────────────────────────────────────
Actor actor = new Actor
{
    Id                  = 201,
    FullName            = "Леонардо ДіКапріо",
    Nationality         = "США",
    DateOfBirth         = new DateTime(1974, 11, 11),
    MoviesCount         = 35,
    AverageMovieRating  = 7.9,
    IsOscarWinner       = true,
    FeePerMovie         = 25_000_000
};

Console.WriteLine(actor);

PrintSeparator('═', 60);
Console.WriteLine("\n✅ Програму виконано успішно.\n");


// ──────────────────────────────────────
// Допоміжний метод
// ──────────────────────────────────────
static void PrintSeparator(char ch, int length)
{
    Console.WriteLine(new string(ch, length));
}
