using Sandbox.Utils;

namespace Develop04;

public class ActivityView : MenuViewBase<ActivityController>
{
    private readonly ActivityController _controller;

    private const int Exit = 0;

    public ActivityView(ActivityController controller)
    {
        _controller = controller;
        var menu = new Dictionary<int, string>
        {
            { (int)ActivityType.Breathing, BreathingActivity.Name },
            { (int)ActivityType.Reflection, ReflectionActivity.Name },
            { (int)ActivityType.Listing, ListingActivity.Name },
        };
        Initialize("Mindfulness Program", menu, Exit);
    }

    public override void ShowMenu()
    {
        int? choice = null;
        while (choice is not Exit)
        {
            choice = ChooseFromMenu();
            if (choice != Exit)
            {
                DoActivity((ActivityType)choice);
            }
        }
    }

    private void DoActivity(ActivityType activityType)
    {
        Console.Clear();
        
        var activity = _controller.CreateActivity(activityType);
        Console.WriteLine($"Welcome to the {activity.GetName()}.");
        Console.WriteLine();
        Console.WriteLine(activity.GetDescription());
        Console.WriteLine();
        var seconds = AskInt("How long, in seconds, would you like for your session? ");
        if (seconds < activity.HowManySecondsAreRequired())
        {
            Console.WriteLine();
            Console.WriteLine($"I'm sorry, this activity works in increments of {activity.HowManySecondsAreRequired()} seconds. ");
            Console.Write("Press enter to return to the menu: ");
            Console.ReadKey();
            return;
        }
        activity.SetDurationSeconds(seconds);
        
        Console.Clear();
        
        Console.Write("Get ready... ");
        ShowSpinner(3);

        Console.WriteLine();
        Console.WriteLine();

        var steps = activity.GetSteps();
        if (steps == null || steps.Count == 0)
        {
            Console.WriteLine($"*** {activity.GetName()} is not runnable. It requires increments of " +
                              $"{activity.HowManySecondsAreRequired()} seconds");
            Console.WriteLine();
            Console.Write("Press enter to return to the menu... ");
            Console.ReadKey();
            return;
        }

        RunSteps(activity);
        
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed {activity.GetDurationSeconds()} seconds of the {activity.GetName()}.");
        ShowSpinner(5);
    }

    private void RunSteps(ActivityBase activity)
    {
        var steps = activity.GetSteps();
        foreach (var step in steps)
        {
            switch (step.Type)
            {
                case ActivityStepType.Print:
                    HandlePrint(step);
                    break;
                case ActivityStepType.PrintLine:
                    HandlePrintLine(step);
                    break;
                case ActivityStepType.Timer:
                    HandleTimer(step);
                    break;
                case ActivityStepType.Input:
                    HandleInput(activity, step);
                    break;
                case ActivityStepType.KeyPress:
                    HandleKeyPress(step);
                    break;
                case ActivityStepType.Spinner:
                    HandleSpinner(step);
                    break;
                case ActivityStepType.ClearScreen:
                    HandleClearScreen(step);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    private static void HandlePrint(ActivityStep step)
    {
        Console.Write(step.Text);
        LineFeed(step);
    }

    private static void HandlePrintLine(ActivityStep step)
    {
        Console.WriteLine(step.Text);
        LineFeed(step);
    }

    private static void HandleTimer(ActivityStep step)
    {
        if (step.Seconds > 0)
        {
            if (!string.IsNullOrEmpty(step.Text))
            {
                Console.Write(step.Text);
            }
            Console.Write(step.Seconds);
            for (var i = step.Seconds - 1; i >= 0; i--)
            {
                Thread.Sleep(1000);
                Console.Write($"\b{i}");
            }
            Console.Write("\b \b");
        }

        LineFeed(step);
    }
    
    private static void HandleKeyPress(ActivityStep step)
    {
        if (!string.IsNullOrEmpty(step.Text))
        {
            Console.Write(step.Text);
        }

        Console.ReadKey();
        
        LineFeed(step);
    }

    private static void LineFeed(ActivityStep step)
    {
        if (step.LineFeed)
        {
            Console.WriteLine();
        }
    }

    private static void HandleClearScreen(ActivityStep step)
    {
        Console.Clear();
        if (!string.IsNullOrEmpty(step.Text))
        {
            Console.Write(step.Text);
        }
        
        LineFeed(step);
    }

    private static void HandleSpinner(ActivityStep step)
    {
        if (!string.IsNullOrEmpty(step.Text))
        {
            Console.Write(step.Text);
        }
        
        ShowSpinner(step.Seconds);
        
        LineFeed(step);
    }
    
    private static void HandleInput(ActivityBase activity, ActivityStep step)
    {
        if (step.RepeatUntilTimesUp)
        {
            var count = 0;
            var until = DateTime.Now.AddSeconds(activity.GetDurationSeconds());
            while (DateTime.Now < until)
            {
                Console.Write(step.Text);
                Console.ReadLine(); // ignoring result for now - unless we decide to do something with them later
                count++;
            }

            if (count > 1 && !string.IsNullOrEmpty(step.TextAfter))
            {
                Console.WriteLine(step.TextAfter.Replace("{count}", count.ToString()));
            }
        }
        else
        {
            Console.Write(step.Text);
            Console.ReadLine();
        }
        
        LineFeed(step);
    }
}