namespace Prep2;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the score: ");
        var score = int.Parse(Console.ReadLine());
        var letterGrade = "F";
        if (score >= 90)
        {
            letterGrade = "A";
        }
        else if (score >= 80)
        {
            letterGrade = "B";
        }
        else if (score >= 70)
        {
            letterGrade = "C";
        }
        else if (score >= 60)
        {
            letterGrade = "D";
        }

        letterGrade += GetPlusMinus(score);
        Console.WriteLine($"Your grade is: {letterGrade}");

        if (score >= 60)
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("Sorry dude. You'll need to retake this one!");
        }
    }

    private static string GetPlusMinus(int score)
    {
        if (score > 60)
        {
            var remainder = score % 10;
            if (score < 90)
            {
                if (remainder >= 7)
                {
                    return "+";
                }
            }

            if (remainder < 3)
            {
                return "-";
            }
        }

        return "";
    }
}