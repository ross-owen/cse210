using Develop02.Journal;

namespace Develop02;

internal class Program
{
    private const string PromptFileName = "prompts.csv";

    static void Main(string[] args)
    {
        var promptService = new PromptService(PromptFileName);
        var controller = new JournalController(promptService);
        var view = new JournalView(controller);
        view.Show();
    }
}