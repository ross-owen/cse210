namespace Develop02.Journal;

public class JournalController : IController
{
    private readonly PromptService _promptService;
    
    private Journal _journal;

    public JournalController(PromptService promptService)
    {
        _promptService = promptService;
        _journal = new Journal();
    }

    public List<JournalEntry> CreateEntry()
    {
        throw new NotImplementedException();
    }

    public void SaveToFile(string fileName)
    {
        throw new NotImplementedException();
    }

    public void ReadFromFile(string fileName)
    {
        throw new NotImplementedException();
    }

    public void DisplayJournal()
    {
        throw new NotImplementedException();
    }
}