namespace DesignPattern;

using static Console;

public class HostDrinkMachine
{
    public enum AvailableDrink
    {
        Coffee,
        Tea
    }

    private readonly Dictionary<AvailableDrink, IHostDrinkFactory> _factories = new();

    public HostDrinkMachine()
    {
        foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
        {
            var typeName = "DesignPattern." + Enum.GetName(typeof(AvailableDrink), drink) + "Factory";
            WriteLine($"___{typeName}");
            var factory = (IHostDrinkFactory) Activator.CreateInstance(Type.GetType(typeName));
            _factories.Add(drink, factory);
        }
    }

    public IHostDrink MakeDrink(AvailableDrink drink, int ammount)
    {
        return _factories[drink].Prepare(ammount);
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