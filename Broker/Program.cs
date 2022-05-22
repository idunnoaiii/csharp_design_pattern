// See https://aka.ms/new-console-template for more information

Broker broker = new Broker();
var goblin = new Creature(broker, "Goblin", 2, 2);
Console.WriteLine(goblin);

using (new DoubleAttackModifier(broker, goblin))
{
    Console.WriteLine(goblin);
}


public class Broker
{
    public event EventHandler<Query> queries;

    public void PerformQuery(object sender, Query q)
        => queries?.Invoke(sender, q);
}

public class Query
{
    public string CreatureName;

    public enum Argument
    {
        Attack, Defence
    }

    public Argument WhatToQuery;

    public int Value;

    public Query(string creatureName, Argument whatToQuery, int value)
    {
        CreatureName = creatureName ?? throw new ArgumentNullException(paramName: nameof(creatureName));
        this.WhatToQuery = whatToQuery;
        this.Value = value;
    }
}

public class Creature
{
    private Broker _broker;
    public string Name;
    private int attack, defense;

    public Creature(Broker broker, string name, int attack, int defense)
    {
        _broker = broker ?? throw new ArgumentNullException(nameof(broker));
        Name = name ?? throw new ArgumentNullException(nameof(name));
        this.attack = attack;
        this.defense = defense; 
    }

    public int Attack
    {
        get
        {
            var q = new Query(Name, Query.Argument.Attack, attack);
            _broker.PerformQuery(this, q);
            return q.Value;
        }
    }
    
    public int Defense
    {
        get
        {
            var q = new Query(Name, Query.Argument.Defence, defense);
            _broker.PerformQuery(this, q);
            return q.Value;
        }
    }

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(Attack)}: {Attack}, {nameof(Defense)}: {Defense}";
    }
}

public abstract class CreatureModifier : IDisposable
{
    protected Broker _broker;
    protected Creature _creature;

    protected CreatureModifier(Broker broker, Creature creature)
    {
        _broker = broker;
        _creature = creature;
        _broker.queries += Handler;
    }

    protected abstract void Handler(object sender, Query q);
    
    public void Dispose()
    {
        _broker.queries -= Handler;
    }
}

public class DoubleAttackModifier : CreatureModifier
{
    public DoubleAttackModifier(Broker broker, Creature creature) : base(broker, creature)
    {
    }

    protected override void Handler(object sender, Query q)
    {
        if (q.CreatureName == _creature.Name && q.WhatToQuery == Query.Argument.Attack)
        {
            q.Value *= 2;
        }
    }
}