// See https://aka.ms/new-console-template for more information

var person = new PersonBuilder()
    .Called("thien")
    .WorkAs("Developer")
    .Build();

Console.WriteLine(person.ToString());

public class Person
{
    public string Name, Position;

    public override string ToString()
    {
        return $"{Name}: {Position}";
    }
}

public abstract class FunctionalBuilder<TSubject, TSelf>
    where TSelf : FunctionalBuilder<TSubject, TSelf>
    where TSubject : new()
{
    private readonly List<Func<TSubject, TSubject>> _actions = new();

    public TSelf Do(Action<TSubject> action)
    {
        return AddAction(action);
    }

    private TSelf AddAction(Action<TSubject> action)
    {
        _actions.Add(
            p =>
            {
                action(p);
                return p;
            });
        return (TSelf) this;
    }

    public TSubject Build()
    {
        return _actions.Aggregate(new TSubject(), (p, f) => f(p));
    }
}

public sealed class PersonBuilder : FunctionalBuilder<Person, PersonBuilder>
{
    public PersonBuilder Called(string name)
    {
        return Do(p => p.Name = name);
    }
}

// public sealed class PersonBuilder
// {
//     private readonly List<Func<Person, Person>> actions = new();
//
//     public PersonBuilder Do(Action<Person> action)
//     {
//         return AddAction(action);
//     }
//
//     private PersonBuilder AddAction(Action<Person> action)
//     {
//         actions.Add(
//             p =>
//             {
//                 action(p);
//                 return p;
//             });
//         return this;
//     }
//
//     public Person Build()
//     {
//         return actions.Aggregate(new Person(), (p, f) => f(p));
//     }
//
//     public PersonBuilder Called(string name)
//     {
//         return Do(p => p.Name = name);
//     }
// }

public static class PersonBuilderExtension
{
    public static PersonBuilder WorkAs(this PersonBuilder builder, string position)
    {
        return builder.Do(p => p.Position = position);
    }
}