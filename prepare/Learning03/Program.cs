namespace Learning03;

class Program
{
    static void Main(string[] args)
    {
        Display(new Fraction());
        Display(new Fraction(5));
        Display(new Fraction(3, 4));
        Display(new Fraction(1, 3));
    }

    private static void Display(Fraction fraction)
    {
        Console.WriteLine(fraction.GetFractionString());
        Console.WriteLine(fraction.GetDecimalValue());
    }
}