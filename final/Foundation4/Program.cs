namespace Foundation4;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        var activities = new List<ActivityBase>
        {
            CreateRunning(),
            CreateCycling(),
            CreateSwimming()
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            var runningActivity = (RunningActivity)activity;
        }
    }

    private static RunningActivity CreateRunning()
    {
        var r = new Random();
        var date = DateTime.Today.AddDays(-1 * r.Next(5));
        var duration = r.Next(20, 301);
        var distance = r.Next(1, 26);
        return new RunningActivity(date, duration, distance);
    }

    private static CyclingActivity CreateCycling()
    {
        var r = new Random();
        var date = DateTime.Today.AddDays(-1 * r.Next(5));
        var duration = r.Next(30, 181);
        var speed = r.Next(10, 31);
        return new CyclingActivity(date, duration, speed);
    }

    private static SwimmingActivity CreateSwimming()
    {
        var r = new Random();
        var date = DateTime.Today.AddDays(-1 * r.Next(5));
        var duration = r.Next(40, 121);
        var lapCount = r.Next(20, 201);
        return new SwimmingActivity(date, duration, lapCount);
    }
}