using System.Text.Json.Serialization;

namespace SwgeChatbotParser.Model.Mission;

public class ChatMissionStep : Step
{
	[JsonPropertyName("chatId")] public string ChatId { get; set; }
}