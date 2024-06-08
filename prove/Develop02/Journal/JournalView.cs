namespace Develop02.Journal;

public class JournalView : ViewBase<JournalController>
{
    private readonly JournalController _controller;
    
    private const int CreateEntry = 1;
    private const int SaveToFile = 2;
    private const int ReadFromFile = 3;
    private const int DisplayEntries = 4;
    private const int Exit = 0;

    public JournalView(JournalController controller)
    {
        _controller = controller;
        var menu = new Dictionary<int, string>
        {
            { CreateEntry, "Create an entry" },
            { SaveToFile, "Save to a file" },
            { ReadFromFile, "Open a file" },
            { DisplayEntries, "Display entries" }
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
                    _controller.CreateEntry();
                    break;
                case SaveToFile:
                    Save();
                    break;
                case ReadFromFile:
                    Open();
                    break;
                case DisplayEntries:
                    _controller.DisplayJournal();
                    break;
            }
        }
    }

    private void Save()
    {
        Console.Write("Enter a filename to save your journal to: ");
        var fileName = Console.ReadLine();
        _controller.SaveToFile(fileName);
    }

    private void Open()
    {
        Console.Write("Enter a filename to open: ");
        var fileName = Console.ReadLine();
        _controller.ReadFromFile(fileName);
    }
}