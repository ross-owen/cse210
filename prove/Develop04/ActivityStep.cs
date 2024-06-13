namespace Develop04;

public class ActivityStep
{
    public ActivityStepType Type { get; set; }
    public string Text { get; set; }
    public int Seconds { get; set; }
    public DateTime EndTime { get; set; }
    public bool LineFeed { get; set; }
}

public enum ActivityStepType
{
    Print,
    PrintLine,
    CountDown,
    Timer,
    KeyPress,
    Input,
    Spinner,
    ClearScreen
}