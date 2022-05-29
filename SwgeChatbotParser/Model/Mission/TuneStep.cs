using System.Text.Json.Serialization;

namespace SwgeChatbotParser.Model.Steps;

public class TuneStep : Step
{
	[JsonPropertyName("difficulty")] public int Difficulty { get; set; }
}