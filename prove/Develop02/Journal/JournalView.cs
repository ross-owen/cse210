namespace Develop02.Journal;

public class JournalView : ViewBase<JournalController>
{
    private readonly JournalController _controller;
    
    private const int CreateEntry = 1;
    private const int DisplayEntries = 2;
    private const int ReadFromFile = 3;
    private const int SaveToFile = 4;
    private const int Exit = 0;

    public JournalView(JournalController controller)
    {
        _controller = controller;
        var menu = new Dictionary<int, string>
        {
            { CreateEntry, "Create an entry" },
            { DisplayEntries, "Display entries" },
            { ReadFromFile, "Open a file" },
            { SaveToFile, "Save to a file" },
        };
        Initialize("Journal Menu", menu, Exit);
    }
    
    public override void Show()
    {
        int? choice = null;
        while (choice is not Exit)
        {
            choice = ChooseFromMenu();
            switch (choice)
            {
                case CreateEntry:
                    AddEntry();
                    break;
                case SaveToFile:
                    Save();
                    break;
                case ReadFromFile:
                    Open();
                    break;
                case DisplayEntries:
                    ShowJournalEntries();
                    break;
            }
        }
    }

    private void AddEntry()
    {
        Console.WriteLine();
        Console.Write("Do you want a prompt? [Y/n] ");
        JournalPrompt prompt = null;
        if (AskYesNo())
        {
            prompt = _controller.GetPrompt();
            Console.WriteLine(prompt.Text);
        }

        Console.Write($"{DateTime.Now:yyyy-MMMM-dd}: ");
        var text = Console.ReadLine();
        if (string.IsNullOrEmpty(text))
        {
            Console.WriteLine("*** Journal text not found.\n");
        }
        else
        {
            _controller.CreateEntry(text, prompt);
            Console.WriteLine();
        }
    }

    private void ShowJournalEntries()
    {
        var journal = _controller.GetJournal();
        if (journal == null)
        {
            HandleJournalDoesNotExist();
        }
        else
        {
            Console.WriteLine("\n\n-----------------------");
            Console.WriteLine(journal.ToString());
            Console.WriteLine("-----------------------");
            foreach (var entry in journal.Entries)
            {
                Console.WriteLine(entry);
            }
            Console.WriteLine("\n");
        }
    }

    private void HandleJournalDoesNotExist()
    {
        Console.WriteLine();
        Console.Write("I'm sorry, you haven't started a journal yet. Would you like to start one? [Y/n] ");
        if (AskYesNo())
        {
            Console.Write("What should we call this journal? [leave blank to use Month Year] ");
            var name = Console.ReadLine();
            var journal = _controller.CreateJournal(string.IsNullOrEmpty(name) ? null : name);
            Console.WriteLine($"Great! We've created a new journal called {journal.Name}!");
        }
        else
        {
            Console.WriteLine("Okay.\n");
        }
    }

    private void Save()
    {
        var journal = _controller.GetJournal();
        if (journal == null)
        {
            HandleJournalDoesNotExist();
        }
        else
        {
            Console.Write("Enter a filename to save your journal to: ");
            var fileName = Console.ReadLine();
            if (string.IsNullOrEmpty(fileName))
            {
                Console.WriteLine("*** Filename is invalid.\n");   
            }
            else
            {
                _controller.SaveToFile(fileName);
            }
        }
    }

    private void Open()
    {
        var journal = _controller.GetJournal();
        var areYouSure = true;
        if (journal is { IsSaved: false, Entries.Count: > 0 })
        {
            Console.Write("You have unsaved changes. Are you sure you want to discard and load the file? [y/N]");
            if (!AskYesNo(userDefault:"N"))
            {
                areYouSure = false;
            }
        }

        if (areYouSure)
        {
            Console.Write("Enter a filename to open: ");
            var fileName = Console.ReadLine();
            if (_controller.DoesJournalExist(fileName))
            {
                _controller.ReadFromFile(fileName);
                ShowJournalEntries();
            }
            else
            {
                Console.WriteLine("*** Journal file does not exist.\n");
            }
        }
    }
}