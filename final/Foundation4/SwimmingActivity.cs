namespace Foundation4;

public class SwimmingActivity : ActivityBase
{
    private readonly int _lapCount;

    public SwimmingActivity(DateTime date, int duration, int lapCount) : base(date, duration)
    {
        _lapCount = lapCount;
    }

    protected override string GetExerciseName()
    {
        return "Swimming";
    }

    protected override double GetDistance()
    {
        return (((double)_lapCount * 50) / 1000) * 0.62;
    }

    protected override double GetSpeed()
    {
        return (GetDistance() / GetDuration()) * 60;
    }

    protected override double GetPace()
    {
        return 60 / GetSpeed();
    }
}