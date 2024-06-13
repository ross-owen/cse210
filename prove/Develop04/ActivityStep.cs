namespace Develop04;

public class ActivityStep
{
    public ActivityStepType Type { get; set; }
    public string Text { get; set; }
    public int Seconds { get; set; }
    public bool LineFeed { get; set; }
    public bool RepeatUntilTimesUp { get; set; }
    public string TextAfter { get; set; }
}

public enum ActivityStepType
{
    Print,
    PrintLine,
    Timer,
    KeyPress,
    Input,
    Spinner,
    ClearScreen
}