using System.Collections;
using System.Diagnostics;
using Core;

Console.OutputEncoding = System.Text.Encoding.UTF8;

// ════════════════════════════════════════════════════════════════════
//  Лабораторна робота №2
//  Система типів CTS, менеджмент пам'яті та LINQ
// ════════════════════════════════════════════════════════════════════

PrintHeader("Лабораторна робота №2 — CTS, пам'ять, LINQ  |  Каталог фільмів");

// ────────────────────────────────────────────────────────────────────
// ЗАВДАННЯ 2: Struct — передача за значенням (Stack)
// ────────────────────────────────────────────────────────────────────
PrintSection("Завдання 2: struct MovieRating — передача за значенням");

var rating = new MovieRating(criticsScore: 8.5, audienceScore: 9.1, votesCount: 120_000);

Console.WriteLine($"  До виклику методу:    {rating}");
ModifyRating(rating);
Console.WriteLine($"  Після виклику методу: {rating}");
Console.WriteLine("  >>> Struct передається за значенням — оригінал залишився незмінним!\n");

static void ModifyRating(MovieRating r)
{
    r.CriticsScore  = 0.0;
    r.AudienceScore = 0.0;
    r.VotesCount    = 0;
    Console.WriteLine($"  Всередині методу:     {r}   (змінена копія)");
}

// ────────────────────────────────────────────────────────────────────
// ЗАВДАННЯ 3: Boxing/Unboxing — ArrayList vs List<int>
// ────────────────────────────────────────────────────────────────────
PrintSection("Завдання 3: Boxing/Unboxing — ArrayList vs List<int> (1 000 000 елементів)");

const int N = 1_000_000;

var sw1 = Stopwatch.StartNew();
var arrayList = new ArrayList();
for (int i = 0; i < N; i++)
    arrayList.Add(i);   // boxing: int → object
sw1.Stop();

var sw2 = Stopwatch.StartNew();
var genericList = new List<int>(N);
for (int i = 0; i < N; i++)
    genericList.Add(i);
sw2.Stop();

Console.WriteLine($"  {"ArrayList  (нетипізований, з boxing):",-42} {sw1.ElapsedMilliseconds,5} мс");
Console.WriteLine($"  {"List<int>  (узагальнений, без boxing):",-42} {sw2.ElapsedMilliseconds,5} мс");
Console.WriteLine($"  {"Різниця:",-42} {sw1.ElapsedMilliseconds - sw2.ElapsedMilliseconds,5} мс");
Console.WriteLine();

int   original = 42;
object boxed   = original;
int   unboxed  = (int)boxed;
Console.WriteLine($"  Boxing:   int {original} → object (тип: {boxed.GetType().Name})");
Console.WriteLine($"  Unboxing: (int)boxed → {unboxed}\n");

// ────────────────────────────────────────────────────────────────────
// ЗАВДАННЯ 4: List<Movie> — 11 об'єктів (клас Movie з ЛР1)
// ────────────────────────────────────────────────────────────────────
PrintSection("Завдання 4: List<Movie> — 11 фільмів");

var movies = new List<Movie>
{
    new Movie { Id=1,  Title="Початок",                Director="Крістофер Нолан",  Genre="Трилер",     ReleaseDate=new DateTime(2010,7,16),  DurationMinutes=148, AverageRating=8.8, IsAvailableOnline=true,  Budget=160_000_000 },
    new Movie { Id=2,  Title="Темний лицар",           Director="Крістофер Нолан",  Genre="Бойовик",    ReleaseDate=new DateTime(2008,7,18),  DurationMinutes=152, AverageRating=9.0, IsAvailableOnline=true,  Budget=185_000_000 },
    new Movie { Id=3,  Title="Інтерстеллар",           Director="Крістофер Нолан",  Genre="Фантастика", ReleaseDate=new DateTime(2014,11,7),  DurationMinutes=169, AverageRating=8.6, IsAvailableOnline=true,  Budget=165_000_000 },
    new Movie { Id=4,  Title="Матриця",                Director="Лана Вачовськи",   Genre="Фантастика", ReleaseDate=new DateTime(1999,3,31),  DurationMinutes=136, AverageRating=8.7, IsAvailableOnline=true,  Budget=63_000_000  },
    new Movie { Id=5,  Title="Бійцівський клуб",       Director="Девід Фінчер",     Genre="Драма",      ReleaseDate=new DateTime(1999,10,15), DurationMinutes=139, AverageRating=8.8, IsAvailableOnline=false, Budget=63_000_000  },
    new Movie { Id=6,  Title="Форрест Гамп",           Director="Роберт Земекіс",   Genre="Драма",      ReleaseDate=new DateTime(1994,7,6),   DurationMinutes=142, AverageRating=8.8, IsAvailableOnline=true,  Budget=55_000_000  },
    new Movie { Id=7,  Title="Список Шиндлера",        Director="Стівен Спілберг",  Genre="Драма",      ReleaseDate=new DateTime(1993,12,15), DurationMinutes=195, AverageRating=9.0, IsAvailableOnline=false, Budget=22_000_000  },
    new Movie { Id=8,  Title="Мовчання ягнят",         Director="Джонатан Демме",   Genre="Трилер",     ReleaseDate=new DateTime(1991,2,14),  DurationMinutes=118, AverageRating=8.6, IsAvailableOnline=true,  Budget=19_000_000  },
    new Movie { Id=9,  Title="Аватар",                 Director="Джеймс Кемерон",   Genre="Фантастика", ReleaseDate=new DateTime(2009,12,18), DurationMinutes=162, AverageRating=7.8, IsAvailableOnline=true,  Budget=237_000_000 },
    new Movie { Id=10, Title="Зоряні війни: Епізод IV",Director="Джордж Лукас",    Genre="Фантастика", ReleaseDate=new DateTime(1977,5,25),  DurationMinutes=121, AverageRating=8.6, IsAvailableOnline=false, Budget=11_000_000  },
    new Movie { Id=11, Title="Термінатор 2",           Director="Джеймс Кемерон",   Genre="Бойовик",    ReleaseDate=new DateTime(1991,7,3),   DurationMinutes=137, AverageRating=8.5, IsAvailableOnline=true,  Budget=102_000_000 },
};

Console.WriteLine($"  Завантажено {movies.Count} фільмів у List<Movie>.");
PrintMovieTable(movies);

// ────────────────────────────────────────────────────────────────────
// ЗАВДАННЯ 5: LINQ Where — фільтрація
// ────────────────────────────────────────────────────────────────────
PrintSection("Завдання 5: LINQ Where — рейтинг > 8.7 та доступні онлайн");

var highRatedOnline = movies
    .Where(m => m.AverageRating > 8.7 && m.IsAvailableOnline)
    .ToList();

Console.WriteLine("  Запит: .Where(m => m.AverageRating > 8.7 && m.IsAvailableOnline)");
PrintMovieTable(highRatedOnline);

// ────────────────────────────────────────────────────────────────────
// ЗАВДАННЯ 6: LINQ OrderBy + ThenByDescending — сортування
// ────────────────────────────────────────────────────────────────────
PrintSection("Завдання 6: LINQ OrderBy + ThenByDescending — жанр ASC, рейтинг DESC");

var sorted = movies
    .OrderBy(m => m.Genre)
    .ThenByDescending(m => m.AverageRating)
    .ToList();

Console.WriteLine("  Запит: .OrderBy(m => m.Genre).ThenByDescending(m => m.AverageRating)");
PrintMovieTable(sorted);

// ────────────────────────────────────────────────────────────────────
// ЗАВДАННЯ 7: LINQ Select — проекція
// ────────────────────────────────────────────────────────────────────
PrintSection("Завдання 7: LINQ Select — проекція (Title, Director, AverageRating)");

var projection = movies
    .OrderByDescending(m => m.AverageRating)
    .Select(m => new { m.Title, m.Director, m.AverageRating })
    .ToList();

Console.WriteLine("  Запит: .OrderByDescending(...).Select(m => new { m.Title, m.Director, m.AverageRating })");
Console.WriteLine();
Console.WriteLine($"  {"№",-4} {"Назва",-30} {"Режисер",-24} {"Рейтинг",9}");
Console.WriteLine("  " + new string('─', 70));
int idx = 1;
foreach (var item in projection)
    Console.WriteLine($"  {idx++,-4} {item.Title,-30} {item.Director,-24} {item.AverageRating,9:F1}");
Console.WriteLine();

// ────────────────────────────────────────────────────────────────────
// ЗАВДАННЯ 8: LINQ FirstOrDefault — пошук
// ────────────────────────────────────────────────────────────────────
PrintSection("Завдання 8: LINQ FirstOrDefault — пошук з обробкою null");

var found = movies.FirstOrDefault(m => m.Director == "Крістофер Нолан" && m.DurationMinutes > 160);
Console.WriteLine("  Запит: .FirstOrDefault(m => m.Director == \"Крістофер Нолан\" && m.DurationMinutes > 160)");
if (found != null)
    Console.WriteLine($"  [ЗНАЙДЕНО]     '{found.Title}'  ({found.DurationMinutes} хв.)  Рейтинг: {found.AverageRating:F1}");
else
    Console.WriteLine("  [НЕ ЗНАЙДЕНО]  Результат: null");

Console.WriteLine();

var notFound = movies.FirstOrDefault(m => m.AverageRating > 10.0);
Console.WriteLine("  Запит: .FirstOrDefault(m => m.AverageRating > 10.0)");
if (notFound == null)
    Console.WriteLine("  [НЕ ЗНАЙДЕНО]  FirstOrDefault повернув null — виняток не виникає (безпечно!)");
Console.WriteLine();

// ────────────────────────────────────────────────────────────────────
// Додатково: агрегатні запити
// ────────────────────────────────────────────────────────────────────
PrintSection("Додатково: агрегатні LINQ-запити");

Console.WriteLine($"  Кількість фільмів:      {movies.Count}");
Console.WriteLine($"  Середній рейтинг:       {movies.Average(m => m.AverageRating):F2}");
Console.WriteLine($"  Максимальний рейтинг:   {movies.Max(m => m.AverageRating):F1}");
Console.WriteLine($"  Найдовший фільм:        {movies.Max(m => m.DurationMinutes)} хв.");
Console.WriteLine($"  Фільмів онлайн:         {movies.Count(m => m.IsAvailableOnline)}");
Console.WriteLine($"  Загальний бюджет:       ${movies.Sum(m => m.Budget):N0}");
Console.WriteLine($"  Жанри:                  {string.Join(", ", movies.Select(m => m.Genre).Distinct().OrderBy(g => g))}");
Console.WriteLine();

Console.WriteLine(new string('═', 72));
Console.WriteLine("  Лабораторна робота №2 виконана успішно.");
Console.WriteLine(new string('═', 72));

// ════════════════════════════════════════════════════════════════════
// Допоміжні методи
// ════════════════════════════════════════════════════════════════════

static void PrintHeader(string title)
{
    Console.WriteLine(new string('═', 72));
    Console.WriteLine($"  {title}");
    Console.WriteLine(new string('═', 72));
    Console.WriteLine();
}

static void PrintSection(string title)
{
    Console.WriteLine(new string('─', 72));
    Console.WriteLine($"  {title}");
    Console.WriteLine(new string('─', 72));
}

static void PrintMovieTable(List<Movie> list)
{
    Console.WriteLine();
    Console.WriteLine($"  {"ID",-4} {"Назва",-30} {"Жанр",-12} {"Рейтинг",8} {"Хв.",5} {"Онлайн",8}");
    Console.WriteLine("  " + new string('─', 71));
    foreach (var m in list)
        Console.WriteLine($"  {m.Id,-4} {m.Title,-30} {m.Genre,-12} {m.AverageRating,8:F1} {m.DurationMinutes,5} {(m.IsAvailableOnline ? "Так" : "Ні"),8}");
    Console.WriteLine($"  Всього: {list.Count} шт.");
    Console.WriteLine();
}
