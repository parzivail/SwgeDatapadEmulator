using System.Text.Json.Serialization;

namespace SwgeChatbotParser;

public class MultiItemRewardStep : Step
{
	[JsonPropertyName("itemIds")] public string[] ItemIds { get; set; } = Array.Empty<string>();
	[JsonPropertyName("notifyPlayer")] public bool NotifyPlayer { get; set; }
	[JsonPropertyName("missionToLinkTo")] public string MissionToLinkTo { get; set; }
	[JsonPropertyName("buttonText")] public string ButtonTextKey { get; set; }
}