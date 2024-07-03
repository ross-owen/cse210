namespace Foundation3;

public class Lecture : EventBase
{
    private readonly string _speaker;
    private readonly int _maxCapacity;
    
    public Lecture(string title, string description, DateTime date, Address address, string speaker, int maxCapacity) : base(title, description, date, address)
    {
        _speaker = speaker;
        _maxCapacity = maxCapacity;
    }

    protected override string GetSpecificDetails()
    {
        return $"Speaker: {_speaker}\n" +
               $"Capacity: {_maxCapacity}\n";
    }

    protected override string GetEventTypeName()
    {
        return "Religious Lecture";
    }
}