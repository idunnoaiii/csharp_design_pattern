// See https://aka.ms/new-console-template for more information

public class Property<T> where T : new()
{
    private T _value;

    public T Value
    {
        get => _value;
        set
        {
            if (Equals(value, this._value)) return;
            this._value = value;
        }
    }
    
    
    public Property()
    {
        
    }

    public Property(T value)
    {
        _value = value;
    }

    public static implicit operator T(Property<T> prop)
    {
        return prop.Value;
    }
}