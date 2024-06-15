namespace Develop05.Goals.Models;

public class EternalGoal : Goal
{
    private int _doneCount;

    public EternalGoal(string shortName, string description, int points) : base(shortName, description, points)
    {
        _doneCount = 0;
    }
    
    public EternalGoal(string shortName, string description, int points, int doneCount) : base(shortName, description, points)
    {
        _doneCount = doneCount;
    }

    public override void RecordEvent()
    {
        _doneCount++;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"{base.GetDetailsString()} -- Completed {_doneCount} times.";
    }

    public int GetDoneCount()
    {
        return _doneCount;
    }
}