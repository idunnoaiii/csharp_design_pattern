// See https://aka.ms/new-console-template for more information


var pb = new PersonBuilder();
var person = pb
    .Works
    .At("Tokyo")
    .AsA("Developer")
    .WithAnualIncome(3000)
    .Lives
    .At("Hiroshima")
    .In("LandMark")
    .WithPostCode("700000");


public class Person
{
    public int AnualIncome;

    public string CompanyName, Position;
    public string StreetAddress, PostCode, City;

    public override string ToString()
    {
        return $"{nameof(StreetAddress)}: {StreetAddress}";
    }
}

public class PersonBuilder
{
    protected Person person = new();
    public PersonJobBuilder Works => new(person);
    public PersonAddressBuilder Lives => new(person);
}

public class PersonJobBuilder : PersonBuilder
{
    public PersonJobBuilder(Person person)
    {
        this.person = person;
    }

    public PersonJobBuilder At(string companyName)
    {
        person.CompanyName = companyName;
        return this;
    }

    public PersonJobBuilder AsA(string position)
    {
        person.Position = position;
        return this;
    }

    public PersonBuilder WithAnualIncome(int income)
    {
        person.AnualIncome = income;
        return this;
    }
}

public class PersonAddressBuilder : PersonBuilder
{
    public PersonAddressBuilder(Person person)
    {
        this.person = person;
    }

    public PersonAddressBuilder At(string companyName)
    {
        person.CompanyName = companyName;
        return this;
    }

    public PersonAddressBuilder In(string city)
    {
        person.City = city;
        return this;
    }

    public PersonAddressBuilder WithPostCode(string postcCode)
    {
        person.PostCode = postcCode;
        return this;
    }
}
