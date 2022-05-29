using System.Text.Json.Serialization;

namespace SwgeChatbotParser.Model.Steps;

public class SignalUnscrambleStep : Step
{
	[JsonPropertyName("difficulty")] public int Difficulty { get; set; }
}