using System.Text.Json.Serialization;

namespace SwgeChatbotParser.Model.Mission;

public class TextTranslateStep : Step
{
	[JsonPropertyName("deeplink")] public DeepLink DeepLink { get; set; }
}