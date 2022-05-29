using System.Text.Json.Serialization;

namespace SwgeChatbotParser.Model;

public record NarrativeReward(
	[property: JsonPropertyName("title")] string TitleKey,
	[property: JsonPropertyName("buttonText")] string ButtonTextKey,
	[property: JsonPropertyName("imagePath")] string ImagePath,
	[property: JsonPropertyName("imageAltText")] string ImageAltTextKey,
	[property: JsonPropertyName("text1")] string Text1Key,
	[property: JsonPropertyName("text2")] string Text2Key,
	[property: JsonPropertyName("text3")] string Text3Key,
	[property: JsonPropertyName("showInChat")] bool ShowInChat,
	[property: JsonPropertyName("chatToShowIn")] string ChatToShowIn,
	[property: JsonPropertyName("missionToShowIn")] string MissionToShowIn,
	[property: JsonPropertyName("missionToLinkTo")] string MissionToLinkTo,
	[property: JsonPropertyName("deepLinkToNextActivity")] bool DeepLinkToNextActivity
);