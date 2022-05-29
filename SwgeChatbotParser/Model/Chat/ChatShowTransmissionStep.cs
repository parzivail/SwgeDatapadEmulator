using System.Text.Json.Serialization;
using SwgeChatbotParser.Model.Mission;

namespace SwgeChatbotParser.Model.Chat;

public class ChatShowTransmissionStep : Step
{
	[JsonPropertyName("transmissionStoryId")] public string TransmissionStoryId { get; set; }
}