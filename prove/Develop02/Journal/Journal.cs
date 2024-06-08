namespace Develop02.Journal;

public class Journal
{
    public string FilePath { get; set; }
    public string Name { get; set; }
    public DateTime FirstEntryDate { get; set; }
    public DateTime LastEntryDate { get; set; }
    public List<JournalEntry> Entries { get; set; } = [];
    public bool IsSaved { get; set; }

    public override string ToString()
    {
        return $"Journal: {Name}";
    }
}