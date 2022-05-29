using System.Text.Json.Serialization;
using SwgeChatbotParser.Model.Mission;

namespace SwgeChatbotParser.Model.Chat;

public class ChatDeeplinkStep : Step
{
	[JsonPropertyName("deeplink")] public DeepLink DeepLink { get; set; }
}