namespace Develop03;

class Program
{
    /// <summary>
    /// EXCEEDS:
    /// Menu system to allow user to add a new scripture
    ///     - saves added scripture to scriptures.json file
    /// Menu to allow user to select a scripture from the saved
    ///     json file
    /// Smart Scripture Mastery creator that derives a "title" from
    ///     the book, chapter, and verses
    /// Allows multiple verses including skipping sequence verses
    /// Uses MVC architecture
    /// Uses random generator to randomly remove / hide words from
    ///     the user.
    /// Uses inheritance from ViewBase class and implements IController
    /// Encapsulates all classes
    /// JSON read/write requires properties from "entities" to be public
    ///     or it won't be able to deserialize the json strings
    ///     - use json attributes to force naming of json fields
    /// Error protection enforcing user data where applicable
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        var projectDir = Path.GetFullPath(@"..\..\..\");
        var scriptureDir = new DirectoryInfo(projectDir);
        var repository = new ScriptureRepository(scriptureDir);
        var controller = new ScriptureController(repository);
        new ScriptureView(controller).ShowMenu();

        // FUNCTIONAL REQUIREMENTS
        // 1. Store a scripture, including both the reference (for example "John 3:16") and the text of the scripture.
        // 2. Accommodate scriptures with multiple verses, such as "Proverbs 3:5-6".
        // 3. Clear the console screen and display the complete scripture, including the reference and the text.
        // 4. Prompt the user to press the enter key or type quit.
        // 5. If the user types quit, the program should end.
        // 6. If the user presses the enter key (without typing quit), the program should hide a few random words in the scripture, clear the console screen, and display the scripture again.
        // 7. The program should continue prompting the user and hiding more words until all words in the scripture are hidden.
        // 8. When all words in the scripture are hidden, the program should end.
        // 9. When selecting the random words to hide, for the core requirements, you can select any word at random, even if the word was already hidden. (As a stretch challenge, try to randomly select from only those words that are not already hidden.)

        // DESIGN REQUIREMENTS
        // 1. Use the principles of Encapsulation, including proper use of classes, methods, public/private access modifiers, and follow good style throughout.
        // 2. Contain at least 3 classes in addition to the Program class: one for the scripture itself, one for the reference (for example "John 3:16"), and to represent a word in the scripture.
        // 3. Provide multiple constructors for the scripture reference to handle the case of a single verse and a verse range ("Proverbs 3:5" or "Proverbs 3:5-6").

        // EXCEEDING REQUIREMENTS
        // 1. Think of other challenges that people find when trying to memorize a scripture. Find a way to have your program help with these challenges.
        // 2. Have your program work with a library of scriptures rather than a single one. Choose scriptures at random to present to the user.
        // 3. Have the program to load scriptures from a files.
        // 4. Anything else you can think of!
    }
}