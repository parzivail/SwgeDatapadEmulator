using System.Text.Json.Serialization;

namespace SwgeChatbotParser.Model.Steps;

public class ManifestStep : Step
{
	[JsonPropertyName("narrativeReward")] public NarrativeReward NarrativeReward { get; set; }
	[JsonPropertyName("additionalAttributes")] public ItemAttribute[] AdditionalAttributes { get; set; } = Array.Empty<ItemAttribute>();
	[JsonPropertyName("title")] public string TitleKey { get; set; }
	[JsonPropertyName("alertText")] public string AlertTextKey { get; set; }
	[JsonPropertyName("buttonText")] public string ButtonTextKey { get; set; }
	[JsonPropertyName("itemId")] public string ItemId { get; set; }
	[JsonPropertyName("awardItem")] public bool AwardItem { get; set; }
	[JsonPropertyName("accentBorder")] public bool AccentBorder { get; set; } = true;
	[JsonPropertyName("showInChatAsManifest")] public bool ShowInChatAsManifest { get; set; } = true;
}