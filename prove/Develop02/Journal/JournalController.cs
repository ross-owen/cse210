using Develop02.Journal.Repos;
using Sandbox.Utils;

namespace Develop02.Journal;

public class JournalController : IController
{
    private readonly PromptRepository _promptRepository;
    private readonly JournalRepository _journalRepository;

    private Journal _journal;

    public JournalController(PromptRepository promptRepository, JournalRepository journalRepository)
    {
        _promptRepository = promptRepository;
        _journalRepository = journalRepository;
    }

    public Journal CreateJournal(string name = null)
    {
        name ??= DateTime.Now.ToString("MMMM yyyy");
        _journal = new Journal
        {
            Name = name
        };
        return _journal;
    }

    public void CreateEntry(string text, JournalPrompt prompt)
    {
        if (_journal == null)
        {
            CreateJournal();
        }

        var entry = new JournalEntry
        {
            Id = Guid.NewGuid(),
            Text = text,
            Prompt = prompt, 
            DateRecorded = DateTime.Now
        };

        _journal?.Entries.Add(entry);
    }

    public void SaveToFile(string fileName)
    {
        if (_journal == null)
        {
            throw new ApplicationException("Journal is null. Check your code.");
        }

        _journalRepository.Save(_journal, fileName);
    }

    public void ReadFromFile(string fileName)
    {
        if (string.IsNullOrEmpty(fileName) || !DoesJournalExist(fileName))
        {
            throw new ArgumentException("Invalid filename. Check your code.");
        }

        _journal = _journalRepository.Open(fileName);
    }

    public JournalPrompt GetPrompt()
    {
        return _promptRepository.GetRandomPrompt();
    }

    public Journal GetJournal()
    {
        return _journal;
    }

    public bool DoesJournalExist(string fileName)
    {
        return !string.IsNullOrEmpty(fileName) && _journalRepository.Exists(fileName);
    }
}