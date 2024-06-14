namespace Learning05;

public class Circle : Shape
{
    private double Radius { get; set; }

    public Circle(string color, double radius) : base(color)
    {
        Radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * (Radius * Radius);
    }
}