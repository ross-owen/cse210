using Develop05.Goals;

namespace Develop05;

class Program
{
    /// <summary>
    /// EXCEEDS REQUIREMENTS
    /// See MenuViewBase.Prompt
    ///     This spawns two threads.
    ///         1) a 5-second timer with a clock spinner
    ///         2) a console read to accept an immediate return from the user
    ///     Whichever thread finishes first will cancel the other. This was a major pitb because there's not a simple
    ///     way to send the enter key into the console app and cancelling the task token source doesn't kill the
    ///     console read.
    /// Also, provides a generic menu system (also in the base class) that handles:
    ///     1) the main menu
    ///     2) goal creation type
    ///     3) select goal to score against
    /// I added a count for the eternal goal so you could see how many times you've completed it, even though it will
    ///     never "complete"
    /// I also added a "unsaved" content check. So if you try to load a file when there are some unsaved content, or
    ///     if you try to exit the application, it will prompt you, informing you that you have unsaved content and
    ///     asks if you want to continue.
    /// After loading a file, I automatically display the contents that was loaded (basically just the list option) 
    /// </summary>
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        var projectDir = Path.GetFullPath(@"..\..\..\");
        var fileDir = new DirectoryInfo(projectDir);

        new GoalManager(new GoalsController(fileDir)).Start();
    }
}