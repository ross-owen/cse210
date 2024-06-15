using System.Text.Json.Serialization;

namespace Develop05.Goals.Entities;

[Serializable]
[JsonDerivedType(typeof(SimpleGoalEntity), typeDiscriminator: "simple")]
[JsonDerivedType(typeof(EternalGoalEntity), typeDiscriminator: "eternal")]
[JsonDerivedType(typeof(ChecklistGoalEntity), typeDiscriminator: "checklist")]
public abstract class GoalEntity
{
   public string ShortName { get; set; }
   public string Description { get; set; }
   public int Points { get; set; }    
}