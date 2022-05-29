using System.Text.Json.Serialization;

namespace SwgeChatbotParser.Model.Steps;

public class DroidHackStep : Step
{
	[JsonPropertyName("droidName")] public string DroidName { get; set; }
	[JsonPropertyName("difficulty")] public int Difficulty { get; set; }
}