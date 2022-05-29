using System.Text.Json.Serialization;
using SwgeChatbotParser.Model.Mission;

namespace SwgeChatbotParser.Model.Rewards;

public class GenericRewardStep : Step
{
	[JsonPropertyName("creditsReward")] public CreditsTransaction CreditsReward { get; set; }
	[JsonPropertyName("factionStanding")] public FactionStanding FactionStanding { get; set; }
}