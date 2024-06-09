using Sandbox.Utils;

namespace Develop03;

public class ScriptureView: ViewBase<ScriptureController>
{
    private readonly ScriptureController _controller;
    private ScriptureMastery _memorizingScripture;
    
    private const int LoadScripture = 1;
    private const int PickScripture = 2;
    private const int Memorize = 3;
    private const int Exit = 0;
    
    public ScriptureView(ScriptureController controller)
    {
        _controller = controller;
        var menu = new Dictionary<int, string>
        {
            { LoadScripture, "Add Your Scripture" },
            { PickScripture, "Pick From Existing" },
            { Memorize, "Memorize" },
        };
        Initialize("Scripture Memory", menu, Exit);
    }

    public override void Show()
    {
        int? choice = null;
        while (choice is not Exit)
        {
            choice = ChooseFromMenu();
            switch (choice)
            {
                case LoadScripture:
                    AddScripture();
                    break;
                case PickScripture:
                    PickAScripture();
                    break;
                case Memorize:
                    PlayGame();
                    break;
            }
        }
    }

    protected override string GetMenuTitle()
    {
        return _memorizingScripture != null 
            ? $"Scripture Memory ({_memorizingScripture.Title})" 
            : base.GetMenuTitle();
    }

    private void AddScripture()
    {
        Console.Clear();
        
        var book = GetBook();
        var chapter = GetChapter();
        var verse = GetVerse();
        var verses = new Dictionary<int, string> { { verse.Number, verse.Text } };

        bool addMoreVerses = true;
        while (addMoreVerses)
        {
            Console.Write("Do you want more verses for this scripture? [y/N] ");
            addMoreVerses = AskYesNo(userDefault: "N");
            if (addMoreVerses)
            {
                verse = GetVerse();
                verses.Add(verse.Number, verse.Text);
            }            
        }
        if (verses.Count > 0)
        {
            _memorizingScripture = _controller.AddScripture(book, chapter, verses);
        }
    }

    private static string GetBook()
    {
        Console.Write("Enter the Book name (ex: 3 Nephi) ");
        return Console.ReadLine();
    }

    private static int GetChapter()
    {
        int? chapter = null;
        while (chapter == null)
        {
            Console.Write("Enter the chapter number: ");
            var userInput = Console.ReadLine();
            if (int.TryParse(userInput, out var i))
            {
                chapter = i;
            }
            else
            {
                Console.WriteLine("*** Invalid chapter number.");
            }
        }

        return chapter.Value;
    }

    private static (int Number, string Text) GetVerse()
    {
        int? verse = null;
        while (verse == null)
        {
            Console.Write("Enter the verse number: ");
            var userInput = Console.ReadLine();
            if (int.TryParse(userInput, out var i))
            {
                verse = i;
            }
            else
            {
                Console.WriteLine("*** Invalid verse number.");
            }
        }
        string text = null;
        while (text == null)
        {
            Console.Write("Enter the verse text: ");
            text = Console.ReadLine();
            if (string.IsNullOrEmpty(text))
            {
                Console.WriteLine("*** Invalid verse text");
                text = null;
            }
        }

        return (verse.Value, text);
    }

    private void PickAScripture()
    {
        Console.Clear();
        Console.WriteLine("Pick from a saved scripture mastery");
        Console.WriteLine("-----------------------------------");
        var savedScriptures = _controller.ListSavedScriptures();
        for (var i = 0; i < savedScriptures.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {savedScriptures[i].Title}");
        }
        Console.WriteLine("-----------------------------------");
        Console.Write("Select an option: ");
        var userInput = Console.ReadLine();
        if (string.IsNullOrEmpty(userInput))
        {
            return;
        }

        if (IsValidOption(Enumerable.Range(1, savedScriptures.Count), userInput, out var item))
        {
            _memorizingScripture = savedScriptures[item - 1];
        }
        else
        {
            Console.WriteLine("*** Invalid selection");
            Thread.Sleep(1500);
        }
    }

    private void PlayGame()
    {
        if (_memorizingScripture == null)
        {
            PickAScripture();
            if (_memorizingScripture == null)
            {
                return;
            }
        }
        
        Console.Clear();
        
        var verses = _memorizingScripture.Verses
            .Select(scriptureVerse => new ScriptureVerseToMemorize(scriptureVerse))
            .ToList();
        
        bool playing = true;
        while (playing)
        {
            Console.WriteLine(_memorizingScripture.Title);
            foreach (var verse in verses)
            {
                Console.WriteLine(verse.ToString());
            }
            
            if (verses.All(v => v.VisibleCount() == 0))
            {
                playing = false;
                Console.Write("\nGood job! Press enter to return to the menu: ");
                Console.ReadLine();
            }
            else 
            {
                Console.Write("\nPress enter to remove two words from each verse. Type 'quit' to end: ");
                var userInput = Console.ReadLine();
                if (userInput != null && userInput.ToUpper() == "QUIT")
                {
                    playing = false;
                }
                else
                {
                    foreach (var verse in verses)
                    {
                        verse.HideWords(2);
                    }

                    Console.Clear();
                }
            }
        }
    }
}