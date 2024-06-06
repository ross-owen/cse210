namespace Prep5;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        var name = PromptUserName();
        var favoriteNumber = PromptUserNumber();
        var squared = favoriteNumber * favoriteNumber;
        Console.WriteLine($"{name}, the square of your number is {squared}");
    }

    private static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    private static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    private static int PromptUserNumber()
    {
        int? favoriteNumber = null;

        while (favoriteNumber is null)
        {
            Console.Write("Please enter your favorite number: ");
            var valueEntered = Console.ReadLine();
            if (int.TryParse(valueEntered, out var fave))
            {
                favoriteNumber = fave;
            }
            else
            {
                Console.WriteLine($"{valueEntered} is not a number.");
            }
        }

        return favoriteNumber.Value;
    }
}