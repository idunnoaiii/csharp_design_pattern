using MoreLinq;

namespace Singleton_db;

public interface IDatabase
{
    int GetPopulation(string name);
}

public class SingletonDatabase : IDatabase
{

    private readonly Dictionary<string, int> _populations;
    
    private readonly static Lazy<SingletonDatabase> _instanceLazy =  new Lazy<SingletonDatabase>(() =>new SingletonDatabase());

    private SingletonDatabase()
    {
        _populations = File.ReadAllLines("capitals.txt")
            .Batch(2)
            .ToDictionary(
                list => list.ElementAt(0).Trim(),
                list => int.Parse(list.ElementAt(1))
            );
    }
    
    public int GetPopulation(string name)
    {
        return _populations[name];
    }

    public static SingletonDatabase Instance => _instanceLazy.Value;
}