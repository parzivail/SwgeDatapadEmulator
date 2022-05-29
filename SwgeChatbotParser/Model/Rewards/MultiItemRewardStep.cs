using System.Text.Json.Serialization;
using SwgeChatbotParser.Model.Mission;

namespace SwgeChatbotParser.Model.Rewards;

public class MultiItemRewardStep : Step
{
	[JsonPropertyName("itemIds")] public string[] ItemIds { get; set; } = Array.Empty<string>();
	[JsonPropertyName("notifyPlayer")] public bool NotifyPlayer { get; set; }
	[JsonPropertyName("missionToLinkTo")] public string MissionToLinkTo { get; set; }
	[JsonPropertyName("buttonText")] public string ButtonTextKey { get; set; }
}