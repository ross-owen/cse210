namespace Foundation4;

public class RunningActivity : ActivityBase
{
    private readonly double _distance;

    public RunningActivity(DateTime date, int duration, double distance) : base(date, duration)
    {
        _distance = distance;
    }

    protected override string GetExerciseName()
    {
        return "Running";
    }

    protected override double GetDistance()
    {
        return _distance;
    }

    protected override double GetSpeed()
    {
        return (_distance / GetDuration()) * 60;
    }

    protected override double GetPace()
    {
        return GetDuration() / _distance;
    }
}