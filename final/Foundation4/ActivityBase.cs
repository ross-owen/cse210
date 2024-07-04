namespace Foundation4;

public abstract class ActivityBase
{
    private readonly DateTime _date;
    private readonly int _duration;     // in minutes

    protected ActivityBase(DateTime date, int duration)
    {
        _date = date;
        _duration = duration;
    }

    protected abstract string GetExerciseName();

    protected abstract double GetDistance();

    protected abstract double GetSpeed();

    protected abstract double GetPace();

    public string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {GetExerciseName()} ({_duration} min) - " +
               $"Distance {GetDistance():N2} miles, " +
               $"Speed {GetSpeed():N2} mph, " +
               $"Pace: {GetPace():N2} min per mile";
    }

    protected int GetDuration()
    {
        return _duration;
    }
}