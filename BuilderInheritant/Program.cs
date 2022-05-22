// See https://aka.ms/new-console-template for more information


// var builder = new PersonAddressBuilder<>();
//
// builder.Called("Teacher").WorkAs("School");


public class Person
{
    public string Name;
    public string Position;
    public string Address;

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}, {nameof(Address)}: {Address}";
    }
}

public abstract class PersonBuilder
{
    protected Person person = new();

    public Person Build() => person;
}

public class PersonInforBuilder<self> : PersonBuilder 
    where self : PersonInforBuilder<self>
{
    public self Called(string name)
    {
        person.Name = name;
        return (self) this;
    }
}

public class PersonJobBuilder<self> : PersonInforBuilder<PersonJobBuilder<self>> 
    where self : PersonJobBuilder<self>
{
    
    public self WorkAs(string position)
    {
        person.Position = position;
        return (self) this;
    }
}

public class PersonAddressBuilder<self> : PersonJobBuilder<PersonAddressBuilder<self>>
    where self : PersonAddressBuilder<self>
{
    public self Lives(string address)
    {
        person.Address = address;
        return (self) this;
    }
}