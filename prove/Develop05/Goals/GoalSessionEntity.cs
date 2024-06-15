using Develop05.Goals.Entities;

namespace Develop05.Goals;

public class GoalSessionEntity
{
    public int Score { get; set; }
    public List<GoalEntity> Goals { get; set; }
}