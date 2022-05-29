using System.Text.Json.Serialization;
using SwgeChatbotParser.Model.Mission;

namespace SwgeChatbotParser.Model.Rewards;

public class FactionStandingRewardStep : Step
{
	[JsonPropertyName("factionStanding")] public FactionStanding FactionStanding { get; set; }
}