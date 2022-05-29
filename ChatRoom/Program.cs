// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");


public class Person
{
    public string Name;
    public ChatRoom Room;
    private List<string> chatLog = new List<string>();

    public Person(string name)
    {
        Name = name;
    }

    public void Say(string message)
    {
        
    }

    public void PrivateMessage(string who, string message)
    {
        
    }
}

public class ChatRoom
{
}