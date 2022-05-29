using System.Text.Json.Serialization;

namespace SwgeChatbotParser.Model.Mission;

public class AudioTranslateStep : Step
{
	[JsonPropertyName("translatedTextKey")] public string TranslatedTextKey { get; set; }
}