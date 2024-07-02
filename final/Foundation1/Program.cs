using System.Text;
using System.Globalization;

namespace Foundation1;

class Program
{
    static void Main(string[] args)
    {
        var videos = new List<Video>
        {
            CreateVideo(),
            CreateVideo(),
            CreateVideo(),
            CreateVideo(),
        };

        Console.Clear();
        foreach (var video in videos)
        {
            PrintInColor("Title", video.GetTitle(), valueColor: ConsoleColor.DarkCyan);
            PrintInColor("Author", video.GetAuthor(), valueColor: ConsoleColor.Green);
            PrintInColor("Length", $"{video.GetLength()} seconds");
            PrintInColor("Comments", $"{video.GetCommentCount()}");
            foreach (var comment in video.GetComments())
            {
                PrintInColor($"• {comment.GetAuthor()}", comment.GetText(), ConsoleColor.Green);
            }
            Console.WriteLine();
        }
    }

    private static Video CreateVideo()
    {
        var textInfo = new CultureInfo("en-US", false).TextInfo;
        var title = textInfo.ToTitleCase(CreateRandomString(30));
        var author = textInfo.ToTitleCase(CreateRandomString(15));
        var length = new Random().Next(300, 1800); // minimum 5-minute, maximum of 30-minute video
        var comments = new List<Comment>();
        var commentCount = new Random().Next(3, 5);
        for (var i = 0; i < commentCount; i++)
        { 
            comments.Add(CreateComment());
        }
        return new Video(title, author, length, comments);
    }

    private static Comment CreateComment()
    {
        var textInfo = new CultureInfo("en-US", false).TextInfo;
        var author = textInfo.ToTitleCase(CreateRandomString(9));
        var text = textInfo.ToTitleCase(CreateRandomString());
        return new Comment(author, text);
    }

    private static string CreateRandomString(int? size = null)
    {
        var length = size ?? new Random().Next(10, 50); // random string will be between 10 and 500 chars
        var builder = new StringBuilder();
        var wordSeparator = 10;
        for (var i = 0; i < length; i++)
        {
            if (i % wordSeparator == 0)
            {
                builder.Append(' '); // add a random space
                wordSeparator = new Random().Next(5, 11);
            }
            var asciiChar = (int)Math.Floor(new Random().NextSingle() * 25) + 97;
            builder.Append(Convert.ToChar(asciiChar));
        }

        return builder.ToString().Trim();
    }

    private static string BuildSeparator(int length)
    {
        var separator = "";
        for (var i = 0; i < length; i++)
        {
            separator += "-";
        }
        return separator;
    }

    private static void PrintInColor(string label, string value, ConsoleColor color = ConsoleColor.Blue, ConsoleColor? valueColor = null)
    {
        var oldColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.Write($"{label}: ");
        Console.ForegroundColor = valueColor ?? oldColor;
        Console.WriteLine(value);
        Console.ForegroundColor = oldColor;
    }
}