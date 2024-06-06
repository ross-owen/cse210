namespace Prep3;

class Program
{
    static void Main(string[] args)
    {
        var playAgain = true;
        while (playAgain)
        {
            var magicNumber = new Random().NextInt64(100);

            var userIsCorrect = false;
            var guessCount = 0;

            while (!userIsCorrect)
            {
                Console.Write("What is your guess? ");
                var userInput = Console.ReadLine();
                var guess = int.Parse(userInput);
                guessCount++;
                if (guess == magicNumber)
                {
                    userIsCorrect = true;
                    Console.WriteLine("You guessed it!");
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine("Lower");
                }
            }

            Console.WriteLine($"It took you {guessCount} guesses.");

            Console.Write("Do you want to play again? [Y/n] ");
            var playAgainUser = Console.ReadLine();
            if (playAgainUser?.ToUpper() != "Y")
            {
                playAgain = false;
            }
        }
    }
}