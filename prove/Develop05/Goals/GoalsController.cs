using System.Text.Json;
using Develop05.Goals.Entities;
using Develop05.Goals.Models;
using Sandbox.Utils;

namespace Develop05.Goals;

public class GoalsController : IController
{
    private readonly DirectoryInfo _fileDir;

    public GoalsController(DirectoryInfo fileDir)
    {
        _fileDir = fileDir;
    }

    public void SaveGoals(string fileName, List<Goal> goals, int score)
    {
        var entity = new GoalSessionEntity
        {
            Score = score,
            Goals = goals.Select(ToEntity).ToList()
        };

        var json = JsonSerializer.Serialize(entity, new JsonSerializerOptions{WriteIndented = true});
        var filePath = new FileInfo(Path.Combine(_fileDir.FullName, fileName)).FullName;
        File.WriteAllText(filePath, json);
    }

    public (List<Goal> goals, int score) LoadGoals(string fileName)
    {
        var file = new FileInfo(Path.Combine(_fileDir.FullName, fileName));
        if (!file.Exists)
        {
            Console.WriteLine("***File was not found.");
            return ([], 0);
        }

        var json = File.ReadAllText(file.FullName);
        if (string.IsNullOrEmpty(json))
        {
            Console.WriteLine("***File was empty.");
            return ([], 0);
        }
        
        var entity = JsonSerializer.Deserialize<GoalSessionEntity>(json);
        return (entity.Goals.Select(ToModel).ToList(), entity.Score);
    }

    private GoalEntity ToEntity(Goal goal)
    {
        GoalEntity entity;
        if (goal.GetType() == typeof(SimpleGoal))
        {
            var simple = (SimpleGoal)goal;
            entity = new SimpleGoalEntity
            {
                ShortName = simple.GetShortName(),
                Description = simple.GetDescription(),
                Points = simple.GetPoints(),
                IsComplete = simple.IsComplete()
            };
        }
        else if (goal.GetType() == typeof(EternalGoal))
        {
            var eternal = (EternalGoal)goal;
            entity = new EternalGoalEntity
            {
                ShortName = eternal.GetShortName(),
                Description = eternal.GetDescription(),
                Points = eternal.GetPoints(),
                DoneCount = eternal.GetDoneCount()
            };
        }
        else if (goal.GetType() == typeof(ChecklistGoal))
        {
            var checklist = (ChecklistGoal)goal;
            entity = new ChecklistGoalEntity
            {
                ShortName = checklist.GetShortName(),
                Description = checklist.GetDescription(),
                Points = checklist.GetPoints(),
                AmountCompleted = checklist.GetAmountCompleted(),
                Target = checklist.GetTarget(),
                Bonus = checklist.GetBonus()
            };
        }
        else
        {
            throw new NotImplementedException("maybe you, as the developer, have implemented a new goal type?");
        }

        return entity;
    }

    private Goal ToModel(GoalEntity entity)
    {
        Goal model;
        if (entity.GetType() == typeof(SimpleGoalEntity))
        {
            var simple = (SimpleGoalEntity)entity;
            model = new SimpleGoal(simple.ShortName, simple.Description, simple.Points, simple.IsComplete);
        }
        else if (entity.GetType() == typeof(EternalGoalEntity))
        {
            var eternal = (EternalGoalEntity)entity;
            model = new EternalGoal(eternal.ShortName, eternal.Description, eternal.Points, eternal.DoneCount);
        }
        else if (entity.GetType() == typeof(ChecklistGoalEntity))
        {
            var checklist = (ChecklistGoalEntity)entity;
            model = new ChecklistGoal(
                checklist.ShortName,
                checklist.Description,
                checklist.Points,
                checklist.Target,
                checklist.Bonus,
                checklist.AmountCompleted);
        }
        else
        {
            throw new NotImplementedException("maybe you, as the developer, have implemented a new goal type?");
        }

        return model;
    }
}