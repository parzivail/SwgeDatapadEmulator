using System.Text.Json.Serialization;

namespace SwgeChatbotParser;

public class NarrativeRewardStep : Step
{
	[JsonPropertyName("narrativeReward")] public NarrativeReward NarrativeReward { get; set; }
}