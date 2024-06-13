namespace Develop04;

public class ListingActivity : ActivityBase
{
    public const string Name = "Listing Activity";

    private const string Description = "This activity will help you reflect on the good things in your life by " +
                                       "having you list as many things as you can in a certain area.";

    private readonly ActivityController _controller;

    // Listing Activity
    // The activity should begin with the standard starting message and prompt for the duration that is used by all activities.
    // The description of this activity should be something like: "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
    // After the starting message, select a random prompt to show the user such as:
        // Who are people that you appreciate?
        // What are personal strengths of yours?
        // Who are people that you have helped this week?
        // When have you felt the Holy Ghost this month?
        // Who are some of your personal heroes?
    // After displaying the prompt, the program should give them a countdown of several seconds to begin thinking about the prompt. Then, it should prompt them to keep listing items.
    // The user lists as many items as they can until they reach the duration specified by the user at the beginning.
    // The activity them displays back the number of items that were entered.
    // The activity should conclude with the standard finishing message for all activities.
    public ListingActivity(ActivityController controller) : base(Name, Description)
    {
        _controller = controller;
    }

    public override int HowManySecondsAreRequired()
    {
        return 5;
    }

    public override List<ActivityStep> GetSteps()
    {
        if (GetDurationSeconds() < HowManySecondsAreRequired())
        {
            return null;
        }

        var steps = new List<ActivityStep>
        {
            new()
            {
                Type = ActivityStepType.PrintLine,
                Text = "List as many responses you can to the following prompt:"
            },
            new()
            {
                Type = ActivityStepType.PrintLine,
                Text = $"--- {_controller.GetRandomPrompt(PromptType.ListingPrompt)} ---"
            },
            new()
            {
                Type = ActivityStepType.Timer,
                Seconds = 5,
                Text = "You may begin in: ",
                LineFeed = true
            },
            new()
            {
                Type = ActivityStepType.Input,
                Text = "> ",
                RepeatUntilTimesUp = true,
                TextAfter = "You listed {count} items!",
            }
        };

        return steps;
    }
}