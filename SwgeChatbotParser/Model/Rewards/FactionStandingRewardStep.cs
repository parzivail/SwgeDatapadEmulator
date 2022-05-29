using System.Text.Json.Serialization;

namespace SwgeChatbotParser;

public class FactionStandingRewardStep : Step
{
	[JsonPropertyName("factionStanding")] public FactionStanding FactionStanding { get; set; }
}