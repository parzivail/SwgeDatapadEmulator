using System.Text.Json.Serialization;
using SwgeChatbotParser.Model.Mission;

namespace SwgeChatbotParser.Model.Chat;

public class ChatNewStateLinkStep : Step
{
	[JsonPropertyName("state")] public string State { get; set; }
	[JsonPropertyName("parameters")] public string Parameters { get; set; }
	[JsonPropertyName("autoTransition")] public bool AutoTransition { get; set; }
}