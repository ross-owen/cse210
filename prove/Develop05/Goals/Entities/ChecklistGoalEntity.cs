namespace Develop05.Goals.Entities;

public class ChecklistGoalEntity : GoalEntity
{
    public int AmountCompleted { get; set; }
    public int Target { get; set; }
    public int Bonus { get; set; }
}