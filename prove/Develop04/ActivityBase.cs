namespace Develop04;

public class ActivityBase
{
    private readonly string _name;
    private readonly string _description;
    private int _durationSeconds;

    protected ActivityBase(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void SetDurationSeconds(int durationSeconds)
    {
        _durationSeconds = durationSeconds;
    }

    public int GetDurationSeconds()
    {
        return _durationSeconds;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    // this should really be an abstract method in an abstract class. :sigh:
    public virtual List<ActivityStep> GetSteps()
    {
        return new List<ActivityStep>();
    }

    public virtual int HowManySecondsAreRequired()
    {
        return 0;
    }
}