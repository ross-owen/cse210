namespace Develop02.Journal;

public class JournalEntry
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public DateTime DateRecorded { get; set; }
    public JournalPrompt Prompt { get; set; }

    public override string ToString()
    {
        var p = "";
        if (Prompt != null)
        {
            p = $"** {Prompt.Text}\n";
        }
        return $"{p}-- {DateRecorded:yyyy/MM/dd}: {Text}";
    }
}