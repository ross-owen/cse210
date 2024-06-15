namespace Develop05.Goals.Models;

public class SimpleGoal : Goal
{
    private bool _isComplete;
    
    public SimpleGoal(string shortName, string description, int points) : base(shortName, description, points)
    {
        _isComplete = false;
    }
    
    public SimpleGoal(string shortName, string description, int points, bool isComplete) : base(shortName, description, points)
    {
        _isComplete = isComplete;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public new string GetStringRepresentation()
    {
        return null;
    }
}