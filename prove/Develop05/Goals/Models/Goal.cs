namespace Develop05.Goals.Models;

public abstract class Goal
{
    private readonly string _shortName;
    private readonly string _description;
    private readonly int _points;

    protected Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent();

    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        return $"{_shortName} ({_description})";
    }

    public string GetShortName()
    {
        return _shortName;
    }

    public string GetDescription()
    {
        return _description;
    }

    public virtual int GetPoints()
    {
        return _points;
    }
}
