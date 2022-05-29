using System.Text.Json.Serialization;
using SwgeChatbotParser.Model.Mission;

namespace SwgeChatbotParser.Model.Chat;

public class BlockingChatButtonStep : Step
{
	[JsonPropertyName("buttonText")] public string ButtonTextKey { get; set; }
}