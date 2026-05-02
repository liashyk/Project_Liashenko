namespace Core;

/// <summary>
/// Приклад класу для управління некерованими ресурсами (лог-файл)
/// </summary>
public class ResourceManager : IDisposable
{
    private readonly StreamWriter _writer;
    private bool _disposed = false;

    public ResourceManager(string operationName)
    {
        _writer = new StreamWriter("lab5_operations.log", true);
        _writer.WriteLine($"[{DateTime.Now:HH:mm:ss}] Початок: {operationName}");
        _writer.Flush();
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            _writer.WriteLine($"[{DateTime.Now:HH:mm:ss}] Кінець операції");
            _writer.Dispose();
            _disposed = true;
        }
    }
}