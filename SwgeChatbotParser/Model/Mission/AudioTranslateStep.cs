using System.Text.Json.Serialization;

namespace SwgeChatbotParser.Model.Steps;

public class AudioTranslateStep : Step
{
	[JsonPropertyName("translatedTextKey")] public string TranslatedTextKey { get; set; }
}