using System.Text.Json.Serialization;

namespace SwgeChatbotParser;

public class GenericRewardStep : Step
{
	[JsonPropertyName("creditsReward")] public CreditsTransaction CreditsReward { get; set; }
	[JsonPropertyName("factionStanding")] public FactionStanding FactionStanding { get; set; }
}