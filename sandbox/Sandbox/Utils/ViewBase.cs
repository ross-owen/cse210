namespace Sandbox.Utils;

public abstract class ViewBase<T> where T : IController
{
    private string _title;
    private Dictionary<int, string> _menu;
    private int _exitKey;

    protected void Initialize(string title, Dictionary<int, string> menu, int exitKey)
    {
        if (menu == null || menu.Count == 0 || menu.ContainsKey(exitKey))
        {
            throw new ArgumentException("menu is invalid. check your code");
        }

        _title = title;
        _menu = menu;
        _exitKey = exitKey;
    }

    protected bool IsValidMenuOption(int option)
    {
        return _menu.ContainsKey(option) || option == _exitKey;
    }

    protected void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine(GetMenuTitle());
        Console.WriteLine("------------------");
        var keys = _menu.Keys;
        foreach (var key in keys)
        {
            if (key != _exitKey)
            {
                Console.WriteLine($"{key}. {_menu[key]}");
            }
        }
        Console.WriteLine("------------------");
        var exitValue = "Exit Menu";
        if (keys.Contains(_exitKey))
        {
            exitValue = _menu[_exitKey];
        }
        Console.WriteLine($"{_exitKey}. {exitValue}\n");
    }
    
    protected int ChooseFromMenu(bool displayMenu = true)
    {
        if (displayMenu)
        {
            DisplayMenu();
        }

        int? choice = null;
        while (choice == null)
        {
            Console.Write("Enter selection: ");
            var userInput = Console.ReadLine();
            if (int.TryParse(userInput, out var i))
            {
                if (_menu.ContainsKey(i) || i == _exitKey)
                {
                    choice = i;
                }
            }

            if (choice == null)
            {
                Console.WriteLine("*** Invalid selection\n");
                DisplayMenu();
            }
        }

        return choice.Value;
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

    public abstract void Show();

    protected virtual string GetMenuTitle()
    {
        return _title;
    }

    protected bool IsValidOption(IEnumerable<int> validOptions, string userInput, out int i)
    {
        if (int.TryParse(userInput, out var result))
        {
            var isValid = validOptions.Any(i => i == result);
            i = result;
            return isValid;
        }

        i = -1;
        return false;
    }
}