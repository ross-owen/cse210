namespace Develop02.Journal;

public class JournalEntry
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public JournalPrompt Prompt { get; set; }
}