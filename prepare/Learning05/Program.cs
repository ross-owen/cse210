namespace Learning05;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes =
        [
            new Square("red", 5),
            new Rectangle("blue", 5, 6),
            new Circle("green", 3)
        ];

        foreach (var shape in shapes)
        {
            Console.WriteLine($"{shape.Color}: {shape.GetArea()}");
        }
    }
}