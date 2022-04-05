// See https://aka.ms/new-console-template for more information


Parallel.For(0, 10, num =>
{
    var s = Singleton.Instance;
    Console.WriteLine("ahihi");
});

public class Singleton
{
    private static Singleton _instance;
    private static readonly SemaphoreSlim _semaphore = new(1, 1);

    private Singleton()
    {
        Console.WriteLine($"{nameof(Singleton)} init");
    }

    public static Singleton Instance
    {
        get
        {
            if (_instance == null)
            {
                _semaphore.Wait();
                if (_instance == null) _instance = new Singleton();
                _semaphore.Release();
            }

            return _instance;
        }
    }
}