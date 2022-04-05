namespace DesignPattern2;

using static Console;

public class HostDrinkMachine
{
    private readonly List<Tuple<string, IHostDrinkFactory>> factories = new();

    public HostDrinkMachine()
    {
        foreach (var t in typeof(HostDrinkMachine).Assembly.GetTypes())
            if (typeof(IHostDrinkFactory).IsAssignableFrom(t)
                && !t.IsInterface)
                factories.Add(Tuple.Create(
                    t.Name.Replace("Factory", string.Empty),
                    (IHostDrinkFactory) Activator.CreateInstance(t)
                ));
    }

    public IHostDrink MakeDrink()
    {
        WriteLine("Available drink:");
        for (var index = 0; index < factories.Count; index++)
        {
            var tuple = factories[index];
            WriteLine($"{index}: {tuple.Item2}");
        }

        return null;
    }
}

public interface IHostDrink
{
    void Consume();
}

public class Tea : IHostDrink
{
    public void Consume()
    {
        WriteLine("Tea");
    }
}

public class Coffee : IHostDrink
{
    public void Consume()
    {
        WriteLine("Coffee");
    }
}

public interface IHostDrinkFactory
{
    IHostDrink Prepare(int ammount);
}

public class TeaFactory : IHostDrinkFactory
{
    public IHostDrink Prepare(int ammount)
    {
        WriteLine("Put in a tea bag...");
        return new Tea();
    }
}

public class CoffeeFactory : IHostDrinkFactory
{
    public IHostDrink Prepare(int ammount)
    {
        WriteLine("Put in a coffee bag...");
        return new Coffee();
    }
}