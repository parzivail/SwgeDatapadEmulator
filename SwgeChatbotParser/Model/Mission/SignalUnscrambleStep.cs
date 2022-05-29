using System.Text.Json.Serialization;

namespace SwgeChatbotParser.Model.Mission;

public class SignalUnscrambleStep : Step
{
	[JsonPropertyName("difficulty")] public int Difficulty { get; set; }
}