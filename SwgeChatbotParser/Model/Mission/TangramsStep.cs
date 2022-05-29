using System.Text.Json.Serialization;

namespace SwgeChatbotParser.Model.Mission;

public class TangramsStep : Step
{
	[JsonPropertyName("difficulty")] public int Difficulty { get; set; }
	[JsonPropertyName("altStyle")] public bool AltStyle { get; set; }
	[JsonPropertyName("levelId")] public string LevelId { get; set; }
}