// See https://aka.ms/new-console-template for more information

var peter = new Person();
var program = new MProgram();

peter.Subscribe(program);

peter.FallIll();



class MProgram: IObserver<Event>
{
    public MProgram()
    {
        
    }

    public void OnCompleted()
    {
        throw new NotImplementedException();
    }

    public void OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(Event value)
    {
        if (value is FallIllsEvent args)
        {
            Console.WriteLine($"Need a docter at {args.Address}");
        }
    }
}

class Event
{
    
}

class FallIllsEvent : Event
{
    public string Address;
}

class Person : IObservable<Event>
{ 
    private HashSet<Subscription> subscriptions = new HashSet<Subscription>();

    public IDisposable Subscribe(IObserver<Event> observer)
    {
        var sub = new Subscription(this, observer);
        subscriptions.Add(sub);
        return sub;
    }

    public void FallIll()
    {
        foreach (var sub in subscriptions)
        {
            sub.Observable.OnNext(new FallIllsEvent
            {
                Address = "221 Barker street"
            });
        }
    }

    private class Subscription : IDisposable
    {
        private Person _person;
        public IObserver<Event> Observable;

        public Subscription(Person person, IObserver<Event> observer)
        {
            this._person = person;
            this.Observable = observer;
        }

        public void Dispose()
        {
            _person.subscriptions.Remove(this);
        }
    }
}