namespace Learning04;

public class Assignment
{
    private readonly string _studentName;
    private readonly string _topic;

    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    protected string GetStudentName()
    {
        return _studentName;
    }
    
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
}