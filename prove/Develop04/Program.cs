namespace Develop04;

class Program
{
    /// <summary>
    /// EXCEEDS REQUIREMENTS
    /// The program is broken out int MVC approach giving the View class the only one able to do a console out
    /// this makes it more applicable and portable to other environments such as web or mobile
    /// Utilizes a controller which utilizes the prompt/question repository
    /// All Activities are dynamically created using a "plug-in" mentality
    /// Uses an Activity Step class where the view knows how to display and ask for items as required by the activity
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        // 1. Have a menu system to allow the user to choose an activity.
        // 2. Each activity should start with a common starting message that provides the name of the activity, a description, and asks for and sets the duration of the activity in seconds. Then, it should tell the user to prepare to begin and pause for several seconds.
        // 3. Each activity should end with a common ending message that tells the user they have done a good job, and pause and then tell them the activity they have completed and the length of time and pauses for several seconds before finishing.
        // 4. Whenever the application pauses it should show some kind of animation to the user, such as a spinner, a countdown timer, or periods being displayed to the screen.
        // 5. The interface for the program should remain generally true to the one shown in the video demo.
        // 6. Provide activities for reflection, breathing, and enumeration, as described below:

        // set the console to unicode so i can show a cooler spinner
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        new ActivityView(new ActivityController(new PromptRepository())).ShowMenu();
    }
}