namespace Core;

/// <summary>
/// Структура для зберігання рейтингу фільму.
/// Value Type — зберігається у Stack, при передачі у метод копіюється.
/// </summary>
public struct MovieRating
{
    /// <summary>Оцінка кінокритиків (0.0 – 10.0).</summary>
    public double CriticsScore { get; set; }

    /// <summary>Оцінка глядачів (0.0 – 10.0).</summary>
    public double AudienceScore { get; set; }

    /// <summary>Кількість голосів.</summary>
    public int VotesCount { get; set; }

    public MovieRating(double criticsScore, double audienceScore, int votesCount)
    {
        CriticsScore  = criticsScore;
        AudienceScore = audienceScore;
        VotesCount    = votesCount;
    }

    public override string ToString() =>
        $"Критики: {CriticsScore:F1} | Глядачі: {AudienceScore:F1} | Голосів: {VotesCount:N0}";
}
