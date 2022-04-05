// from: 


public class Director
{
    public void Construct(IBuilder builder)
    {
        builder.BuildPartA();
        builder.BuildPartB();
        builder.BuildPartC();
        builder.Build();
    }
}


public interface IBuilder
{
    void BuildPartA();
    void BuildPartB();
    void BuildPartC();
    void Build();
}


public class ConcreteBuiderA : IBuilder
{
    private readonly Product _product = new();

    public void BuildPartA()
    {
        _product.Add("ConcreteBuiderA add partA");
    }

    public void BuildPartB()
    {
        _product.Add("ConcreteBuiderA add partA");
    }

    public void BuildPartC()
    {
        _product.Add("ConcreteBuiderA add partA");
    }

    public void Build()
    {
    }
}


public class Product
{
    private List<string> _parts { get; set; }

    public void Add(string part)
    {
        _parts.Add(part);
    }

    public void Show()
    {
        Console.WriteLine("Product parts ----");
        foreach (var p in _parts) Console.WriteLine(p);
    }
}