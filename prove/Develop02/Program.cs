using Develop02.Journal;
using Develop02.Journal.Repos;

namespace Develop02;

internal class Program
{
    private const string PromptFileName = "journal-prompts.csv";

    static void Main(string[] args)
    {
        var projectDir = Path.GetFullPath(@"..\..\..\");
        var journalDir = Path.Combine(projectDir, "Journal");
        var promptFilePath = Path.Combine(journalDir, PromptFileName);

        var promptRepository = new PromptRepository(new FileInfo(promptFilePath));
        var journalRepository = new JournalRepository(new DirectoryInfo(journalDir));
        
        var controller = new JournalController(promptRepository, journalRepository);
        
        new JournalView(controller).Show();
    }
}