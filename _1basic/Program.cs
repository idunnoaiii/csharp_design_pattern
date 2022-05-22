// See https://aka.ms/new-console-template for more information

using System.Collections.ObjectModel;

Console.WriteLine("Hello, World!");

public void DrawPoint(Point p)
{
    Console.WriteLine(p);
}

public class Line
{
    public Point Start, End;

    public Line(Point start, Point end)
    {
        _ = start ?? throw new ArgumentNullException(paramName: nameof(start));
        _ = end ?? throw new ArgumentNullException(paramName: nameof(end));
        Start = start;
        End = end;
    }
}

public class VectorOject : Collection<Line>
{
    
}

public class Point
{
    public int X, Y;

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}