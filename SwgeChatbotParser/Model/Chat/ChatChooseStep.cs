using System.Text.Json.Serialization;
using SwgeChatbotParser.Model.Mission;

namespace SwgeChatbotParser.Model.Chat;

public class ChatChooseStep : Step
{
	[JsonPropertyName("name")] public string Name { get; set; }
}