namespace Develop04;

public class ReflectionActivity : ActivityBase
{
    public const string Name = "Reflection Activity";

    private const string Description = "This activity will help you reflect on times in your life when you have " +
                                       "shown strength and resilience. This will help you recognize the power you " +
                                       "have and how you can use it in other aspects of your life.";

    private readonly ActivityController _controller;

    // Reflection Activity
    // The activity should begin with the standard starting message and prompt for the duration that is used by all activities.
    // The description of this activity should be something like: "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."
    // After the starting message, select a random prompt to show the user such as:
        // Think of a time when you stood up for someone else.
        // Think of a time when you did something really difficult.
        // Think of a time when you helped someone in need.
        // Think of a time when you did something truly selfless.
    // After displaying the prompt, the program should ask the to reflect on questions that relate to this experience. These questions should be pulled from a list such as the following:
        // Why was this experience meaningful to you?
        // Have you ever done anything like this before?
        // How did you get started?
        // How did you feel when it was complete?
        // What made this time different than other times when you were not as successful?
        // What is your favorite thing about this experience?
        // What could you learn from this experience that applies to other situations?
        // What did you learn about yourself through this experience?
        // How can you keep this experience in mind in the future?
    // After each question the program should pause for several seconds before continuing to the next one. While the program is paused it should display a kind of spinner.
    // It should continue showing random questions until it has reached the number of seconds the user specified for the duration.
    // The activity should conclude with the standard finishing message for all activities.
    public ReflectionActivity(ActivityController controller) : base(Name, Description)
    {
        _controller = controller;
    }

    public override int HowManySecondsAreRequired()
    {
        return 15;
    }

    public override List<ActivityStep> GetSteps()
    {
        if (GetDurationSeconds() < HowManySecondsAreRequired())
        {
            return null;
        }
        
        var steps = new List<ActivityStep>();

        steps.Add(new ActivityStep
        {
            Type = ActivityStepType.PrintLine,
            Text = "Consider the following prompt:",
            LineFeed = true
        });
        steps.Add(new ActivityStep
        {
            Type = ActivityStepType.PrintLine,
            Text = $"--- {_controller.GetRandomPrompt(PromptType.ReflectionPrompt)} ---",
            LineFeed = true
        });
        steps.Add(new ActivityStep
        {
            Type = ActivityStepType.KeyPress,
            Text = "When you have something in mind, press enter to continue... "
        });
        steps.Add(new ActivityStep
        {
            Type = ActivityStepType.PrintLine,
            Text = "Now ponder on the following questions as they related to this experience."
        });
        steps.Add(new ActivityStep
        {
            Type = ActivityStepType.Timer,
            Seconds = 4,
            Text = "You may begin in: "
        });
        steps.Add(new ActivityStep
        {
            Type = ActivityStepType.ClearScreen
        });
        // each question allows 15 seconds to ponder
        // this activity requires a minimum of 15 seconds
        // divide the duration seconds by 15 to determine how many questions we'll display
        var quantity = GetDurationSeconds() / HowManySecondsAreRequired();
        steps.AddRange(_controller.GetRandomQuestions(quantity)
            .Select(promptQuestion => new ActivityStep
            {
                Type = ActivityStepType.Spinner, 
                Seconds = HowManySecondsAreRequired(), 
                Text = $"> {promptQuestion} ",
                LineFeed = true
            }));

        return steps;
    }
}