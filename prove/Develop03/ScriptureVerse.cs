using System.Text.Json.Serialization;

namespace Develop03;

public class ScriptureVerse
{
    [JsonPropertyName("verse")]
    public int Verse { get; set; }
    [JsonPropertyName("text")]
    public string Text { get; set; }
}