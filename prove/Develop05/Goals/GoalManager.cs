using Develop05.Goals.Models;
using Develop05.Utils;

namespace Develop05.Goals;

public class GoalManager : MenuViewBase
{
    // MAIN MENU ITEMS
    private const int CreateNewGoalMenu = 1;
    private const int ListGoalsMenu = 2;
    private const int SaveGoalsMenu = 3;
    private const int LoadGoalsMenu = 4;
    private const int RecordEventMenu = 5;

    // CREATE GOAL MENU ITEMS
    private const int SimpleGoalMenu = 1;
    private const int EternalGoalMenu = 2;
    private const int ChecklistGoalMenu = 3;

    // EXIT MENU ITEM FOR ALL MENUS
    private const int ExitMenu = 0;

    private readonly GoalsController _controller;
    
    private List<Goal> _goals;
    private int _score;
    private bool _isSaved;

    public GoalManager(GoalsController controller) : base(ExitMenu) {
        _controller = controller;
        _goals = [];
        _score = 0;
        _isSaved = true;
    }

    public override void Start()
    {
        var menu = new Dictionary<int, string>
        {
            { CreateNewGoalMenu, "Create new goal" },
            { ListGoalsMenu, "List goals" },
            { SaveGoalsMenu, "Save goals" },
            { LoadGoalsMenu, "Load goals" },
            { RecordEventMenu, "Record event" },
        };

        int? choice = null;
        while (choice is not ExitMenu)
        {
            DisplayPlayerInfo();
            choice = ChooseFromMenu("Eternal Quest", menu);
            switch (choice)
            {
                case CreateNewGoalMenu:
                    CreateGoal();
                    break;
                case ListGoalsMenu:
                    ListGoalNames();
                    break;
                case SaveGoalsMenu:
                    SaveGoals();
                    break;
                case LoadGoalsMenu:
                    LoadGoals();
                    break;
                case RecordEventMenu:
                    RecordEvent();
                    break;
                case ExitMenu:
                    if (!_isSaved)
                    {
                        Console.Write("You have unsaved changes. Do you want to continue? [y/N] ");
                        if (!AskYesNo(userDefault: "N"))
                        {
                            choice = -1;
                        }
                    }
                    break;
            }
            Console.Clear();
        }
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine($"Your have {_score} points");
        Console.WriteLine();
    }

    private void ListGoalNames()
    {
        Console.Clear();
        
        if (ShowNoGoalsError())
        {
            return;
        }

        var goalNumber = 1;
        foreach (var goal in _goals)
        {
            var completed = goal.IsComplete() ? "X" : " ";
            Console.WriteLine($"{goalNumber++}. [{completed}] {goal.GetDetailsString()}");
        }
        Prompt("Press enter to return to the menu: ");
    }

    private void CreateGoal()
    {
        Console.Clear();
        var menu = new Dictionary<int, string>
        {
            { SimpleGoalMenu, "Simple goal" },
            { EternalGoalMenu, "Eternal goal" },
            { ChecklistGoalMenu, "Checklist goal" }
        };

        var choice = ChooseFromMenu("The types of Goals are:", menu);
        switch (choice)
        {
            case SimpleGoalMenu:
                CreateSimpleGoal();
                break;
            case EternalGoalMenu:
                CreateEternalGoal();
                break;
            case ChecklistGoalMenu:
                CreateChecklistGoal();
                break;
        }

        _isSaved = false;
    }

    private void RecordEvent()
    {
        Console.Clear();
        if (ShowNoGoalsError())
        {
            return;
        }

        var goalNumber = 1;
        // build the menu from the goals
        var menu = _goals.ToDictionary(goal => goalNumber++, goal => goal.GetShortName());

        var choice = ChooseFromMenu("Your Goals", menu, "Which goal did you accomplish? ");
        if (choice == ExitMenu)
        {
            return;
        }

        // since we are numbered starting at 1, and our index starts at 0
        // subtract one from the choice
        var goal = _goals[choice - 1];
        
        // record the event and get the points (imo, the record event should just return the points earned)
        goal.RecordEvent();
        var points = goal.GetPoints();
        _score += points;
        _isSaved = false;
        
        Console.WriteLine($"Congratulations! You have earned {points} points!");
        Prompt("Press enter to return to the menu: ");
    }

    private void SaveGoals()
    {
        if (ShowNoGoalsError())
        {
            return;
        }

        if (_isSaved)
        {
            Prompt("There is nothing to save. Press enter to return to the menu: ");
            return;
        }
        var fileName = AskString("What is the filename for the goal file? ", allowEmpty: true);
        if (string.IsNullOrEmpty(fileName))
        {
            Prompt("Invalid filename. Press enter to return to the menu: ");
            return;
        }
        _controller.SaveGoals(fileName, _goals, _score);
        _isSaved = true;
    }

    private void LoadGoals()
    {
        if (!_isSaved)
        {
            Console.Write("You have unsaved changes. Do you want to continue? [y/N] ");
            if (!AskYesNo(userDefault: "N"))
            {
                Prompt("Press enter to return to the menu: ");
                return;
            }
        }
        
        var fileName = AskString("What is the filename for the goal file? ", noBreak: true, allowEmpty: true);
        if (string.IsNullOrEmpty(fileName))
        {
            Prompt("Invalid filename. Press enter to return to the menu: ");
            return;
        }
        var (goals, score) = _controller.LoadGoals(fileName);
        _goals = goals;
        _score = score;
        ListGoalNames();
    }

    private void CreateSimpleGoal()
    {
        Console.WriteLine();
        Console.WriteLine("*** Simple Goal ***");
        var (name, description, points) = CollectBaseValues();
        var goal = new SimpleGoal(name, description, points);
        _goals.Add(goal);
    }

    private void CreateEternalGoal()
    {
        Console.WriteLine();
        Console.WriteLine("*** Eternal Goal ***");
        var (name, description, points) = CollectBaseValues();
        var goal = new EternalGoal(name, description, points);
        _goals.Add(goal);
    }

    private void CreateChecklistGoal()
    {
        Console.WriteLine();
        Console.WriteLine("*** Checklist Goal ***");
        var (name, description, points) = CollectBaseValues();
        var target = AskInt("How many times is required for a bonus? ");
        var bonus = AskInt("What is the bonus amount? ");
        var goal = new ChecklistGoal(name, description, points, target, bonus);
        _goals.Add(goal);
    }

    private (string, string, int) CollectBaseValues()
    {
        var name = AskString("What is the name of your goal? ");
        var description = AskString("Give a short description: ");
        var points = AskInt("How many points should this be worth? ");
        return (name, description, points);
    }

    private bool ShowNoGoalsError()
    {
        if (_goals != null && _goals.Count != 0)
        {
            return false;
        }
        
        Console.WriteLine("You don't have any goals yet.");
        Prompt("Press enter to return to the menu: ", beginWithLineBreak: false);
        return true;

    }
}