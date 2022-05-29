using System.Text.Json.Serialization;
using SwgeChatbotParser.Model.Mission;

namespace SwgeChatbotParser.Model.Chat;

public class ChatImageStep : Step
{
	[JsonPropertyName("imagePath")] public string ImagePath { get; set; }
	[JsonPropertyName("speaker")] public ChatSpeaker Speaker { get; set; }
	[JsonPropertyName("altText")] public string AltTextKey { get; set; }
}