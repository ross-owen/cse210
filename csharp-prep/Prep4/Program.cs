namespace Prep4;

class Program
{
    static void Main(string[] args)
    {
        var number = -1;
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        var numbers = new List<int>();
        while (number != 0)
        {
            Console.Write("Enter number: ");
            var userNumber = Console.ReadLine();
            if (int.TryParse(userNumber, out number))
            {
                if (number != 0)
                {
                    numbers.Add(number);
                }
            }
            else
            {
                Console.WriteLine($"{userNumber} is not a number");
                number = -1;
            }
        }

        var sum = numbers.Sum(n => n);
        var average = ((float)sum) / numbers.Count;
        var max = numbers.Max(n => n);
        var smallestPositive = numbers.Where(n => n > 0).Min(n => n);
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        Console.WriteLine("The sorted list is:");
        numbers.Sort();
        foreach (var n in numbers)
        {
            Console.WriteLine(n);
        }
    }
}