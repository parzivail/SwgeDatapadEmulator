using System.Text.Json.Serialization;
using SwgeChatbotParser.Model.Mission;

namespace SwgeChatbotParser.Model.Rewards;

public class NarrativeRewardStep : Step
{
	[JsonPropertyName("narrativeReward")] public NarrativeReward NarrativeReward { get; set; }
}