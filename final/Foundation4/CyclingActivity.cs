namespace Foundation4;

public class CyclingActivity : ActivityBase
{
    private readonly double _speed;     // miles/hour

    public CyclingActivity(DateTime date, int duration, double speed) : base(date, duration)
    {
        _speed = speed;
    }

    protected override string GetExerciseName()
    {
        return "Cycling";
    }

    protected override double GetDistance()
    {
        // distance = rate * time
        // d = r(miles/hour)  * t(min)(hour/60min)
        var timeInHours = (double)GetDuration() / 60;
        return _speed * timeInHours;
    }

    protected override double GetSpeed()
    {
        return _speed;
    }

    protected override double GetPace()
    {
        return 60 / _speed;
    }
}