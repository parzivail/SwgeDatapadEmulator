using System.Text.Json.Serialization;

namespace SwgeChatbotParser.Model.Chat;

public class Chat : Action
{
	[JsonPropertyName("contactId")] public string ContactId { get; set; }
	[JsonPropertyName("chatToChatAutoLinkEnabled")] public bool ChatToChatAutoLinkEnabled { get; set; } = true;
}