namespace Learning05;

public class Shape
{
    public string Color { get; set; }

    protected Shape(string color)
    {
        Color = color;
    }

    public virtual double GetArea()
    {
        return 0.0;
    }
}