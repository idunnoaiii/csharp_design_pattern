// See https://aka.ms/new-console-template for more information

foreach (var i in Enumerable.Range(1, 10))
    Parallel.Invoke(() =>
    {
        var s = Singleton.Instance;
        Console.WriteLine("ahihi");
    });

public class Singleton
{
    private static readonly Lazy<Singleton> _lazy = new(() => new Singleton());

    private Singleton()
    {
        Console.WriteLine($"{nameof(Singleton)} init");
    }

    public static Singleton Instance => _lazy.Value;

    private class Nested
    {
        internal static readonly Singleton Instance = new();
    }
}