namespace Develop02.Journal;

public class Journal
{
    public string Name { get; set; }
    public DateTime FirstEntryDate { get; set; }
    public DateTime LastEntryDate { get; set; }
    public List<JournalEntry> Entries { get; set; } = [];
}