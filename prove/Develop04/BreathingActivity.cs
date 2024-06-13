namespace Develop04;

public class BreathingActivity : ActivityBase
{
    public const string Name = "Breathing Activity";

    private const string Description =
        "This activity will help you relax by walking you through breathing in and out slowly. " +
        "Clear your mind and focus on your breathing.";

// Breathing Activity
// The activity should begin with the standard starting message and prompt for the duration that is used by all activities.
// The description of this activity should be something like: "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing."
// After the starting message, the user is shown a series of messages alternating between "Breathe in..." and "Breathe out..."

// After each message, the program should pause for several seconds and show a countdown.
// It should continue until it has reached the number of seconds the user specified for the duration.
// The activity should conclude with the standard finishing message for all activities.
    public BreathingActivity() : base(Name, Description)
    {
    }

    public override int HowManySecondsAreRequired()
    {
        return 10;
    }

    public override List<ActivityStep> GetSteps()
    {
        if (GetDurationSeconds() < 10)
        {
            return null;
        }
        
        // get whole numbers and do as many as we can for the set duration seconds
        var steps = new List<ActivityStep>();
        
        var repeat = GetDurationSeconds() / 10;
        for (var i = 0; i < repeat; i++)
        {
            steps.Add(new ActivityStep
            {
                Type = ActivityStepType.Print,
                Text = "Breathe in... "
            });
            steps.Add(new ActivityStep()
            {
                Type = ActivityStepType.Timer,
                Seconds = 5,
                LineFeed = true
            });
            steps.Add(new ActivityStep()
            {
                Type = ActivityStepType.Print,
                Text = "Now breathe out... ",
            });
            steps.Add(new ActivityStep()
            {
                Type = ActivityStepType.Timer,
                Seconds = 5,
                LineFeed = true
            });
            steps.Add(new ActivityStep
            {
                Type = ActivityStepType.PrintLine,
                Text = ""
            });
        }

        return steps;
    }
}