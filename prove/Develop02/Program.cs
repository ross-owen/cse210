using Develop02.Journal;
using Develop02.Journal.Repos;

namespace Develop02;

internal class Program
{
    private const string PromptFileName = "journal-prompts.csv";

    /// <summary>
    /// Exceeds requirements by:
    /// - uses JSON to save and read from a journal file
    /// - includes other information in the journal including saved date, title of the journal, most recent post
    /// oldest post
    /// - includes a Guid identifier for the prompts
    /// - includes a Guid identifier for the journal entry
    /// - uses MVC type OOP separating logic and responsibility
    ///     - View uses an abstract base class, allowing for future reuse of menus
    ///     - All display logic is contained within the View class
    ///     - Uses a controller and has an interface for the controller using generics in the view base class
    ///     - requiring the defined controller type    
    /// - uses more advanced techniques using LINQ, etc...
    /// - uses repository classes to serve like a database but with files.
    /// - reads a flat file for prompts, but json files for the journals
    /// - uses a random selection for prompts utilizing the list size as the dimensions
    /// - uses "protected" accessor type for base class allowing only inheritors to use the methods
    ///     - see abstraction and encapsulation
    /// </summary>
    /// <param name="args"></param>
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