using System.Text.Json.Serialization;

namespace SwgeChatbotParser.Model.Steps;

public class TextTranslateStep : Step
{
	[JsonPropertyName("deeplink")] public DeepLink DeepLink { get; set; }
}