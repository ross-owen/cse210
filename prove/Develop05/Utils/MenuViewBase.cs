using System.Collections.Concurrent;

namespace Develop05.Utils;

public abstract class MenuViewBase
{
    private readonly int _exitKey;

    protected MenuViewBase(int exitKey)
    {
        _exitKey = exitKey;
    }

    public abstract void Start();

    protected int ChooseFromMenu(string title, Dictionary<int, string> menu, string enterSelectionPrompt = null)
    {
        DisplayMenu(title, menu);

        int? choice = null;
        while (choice == null)
        {
            if (string.IsNullOrEmpty(enterSelectionPrompt))
            {
                Console.Write("Enter selection: ");
            }
            else
            {
                Console.Write(enterSelectionPrompt);
            }

            var userInput = Console.ReadLine();
            if (int.TryParse(userInput, out var i))
            {
                if (menu.ContainsKey(i) || i == _exitKey)
                {
                    choice = i;
                }
            }

            if (choice == null)
            {
                Console.Write("*** Invalid selection.  ");
                ShowSpinner(2);
                Console.Clear();
                
                DisplayMenu(title, menu);
            }
        }

        return choice.Value;
    }

    private void DisplayMenu(string title, Dictionary<int, string> menu)
    {
        Console.WriteLine(title);
        Console.WriteLine("------------------");
        var keys = menu.Keys;
        foreach (var key in keys)
        {
            if (key != _exitKey)
            {
                Console.WriteLine($"{key}. {menu[key]}");
            }
        }

        Console.WriteLine("------------------");
        Console.WriteLine($"{_exitKey}. Exit Menu\n");
    }

    protected static int AskInt(string question, bool noBreak = true)
    {
        int? i = null;

        while (i == null)
        {
            if (noBreak)
            {
                Console.Write(question);
            }
            else
            {
                Console.WriteLine(question);
            }

            var userInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(userInput) && int.TryParse(userInput, out var value))
            {
                i = value;
            }
            else
            {
                Console.WriteLine("***Invalid entry.");
                Console.WriteLine();
            }
        }

        return i.Value;
    }

    protected static string AskString(string question, bool noBreak = true, bool allowEmpty = false)
    {
        if (noBreak)
        {
            Console.Write(question);
        }
        else
        {
            Console.WriteLine(question);
        }

        var answer = Console.ReadLine();
        while (string.IsNullOrEmpty(answer) && !allowEmpty)
        {
            Console.WriteLine("Sorry. You must provide a value.  Please try again: ");
            answer = Console.ReadLine();
        }

        return answer;
    }

    private static void ShowSpinner(int seconds, bool blink = false)
    {
        // start with a space, so I can backspace over it 
        // allows my loop to be the same
        Console.Write(" ");
        var spinner = new[] { '↑', '↗', '→', '↘', '↓', '↙', '←', '↖' };
        if (blink)
        {
            spinner = new[] { ' ', '_', ' ', '_' };
        }

        // one round is 1 second
        // 8 characters in the spinner equates to 125 milliseconds each
        for (var i = 0; i < seconds; i++)
        {
            foreach (var c in spinner)
            {
                Console.Write($"\b{c}");
                Thread.Sleep(1000 / spinner.Length);
            }
        }

        // back up, replace with a space, then back up again
        Console.Write("\b \b");
    }

    protected static void Prompt(string prompt, bool beginWithLineBreak = true)
    {
        Console.WriteLine();
        Console.Write($"{prompt}    ");

        // create two threads.
        // whichever one finishes first will cancel the other
        var cancelSource = new CancellationTokenSource();
        var token = cancelSource.Token;
        var tasks = new ConcurrentBag<Task>();

        // start a countdown timer thread
        var timer = Task.Factory.StartNew(() => ShowCountdown(5, cancelSource), token);
        tasks.Add(timer);

        // start a read line thread
        // var read = Task.Factory.StartNew(() => Console.ReadLine(), token);
        var read = HackToAllowCancelReadLine(token);
        tasks.Add(read);

        Task.WaitAny(new[] { timer, read });

        cancelSource.Cancel();

        Task.WhenAll(tasks).Wait();
    }

    private static void ShowCountdown(int seconds, CancellationTokenSource cancel)
    {
        var spinner = new[] { '◴', '◷', '◶', '◵' };
        var i = 0;

        try
        {
            while (!cancel.Token.IsCancellationRequested && seconds > 0)
            {
                Console.Write($"\b\b\b\b{seconds} {spinner[i++]} ");
                Thread.Sleep(250);
                if (i == spinner.Length - 1)
                {
                    // one full round, subtract a second and start over
                    i = 0;
                    seconds--;
                }
            }
        }
        finally
        {
            Console.WriteLine("\b\b\b\b    \b\b\b\b");
        }
    }

    private static Task HackToAllowCancelReadLine(CancellationToken token)
    {
        var task = Task.Run(() =>
        {
            try
            {
                ConsoleKeyInfo keyInfo;
                do
                {
                    while (!Console.KeyAvailable)
                    {
                        token.ThrowIfCancellationRequested();
                        Thread.Sleep(50);
                    }

                    keyInfo = Console.ReadKey();
                    if (keyInfo.Key != ConsoleKey.Enter)
                    {
                        Console.Write("\b \b");
                    }
                } while (keyInfo.Key != ConsoleKey.Enter);

                Console.WriteLine();
            }
            catch
            {
                // ignored
            }
        }, token);
        return task;
    }
    
    protected bool AskYesNo(string userDefault = "Y")
    {
        var userAnswer = Console.ReadLine();
        if (string.IsNullOrEmpty(userAnswer))
        {
            userAnswer = userDefault;
        }

        return userAnswer.ToUpper().Equals("Y");
    }
}