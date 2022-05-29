using System.Text.Json.Serialization;
using SwgeChatbotParser.Model.Mission;

namespace SwgeChatbotParser.Model.Chat;

public class ChatMessageStep : Step, ITranslatable
{
	[JsonPropertyName("speaker")] public ChatSpeaker Speaker { get; set; }
	[JsonPropertyName("messageKey")] public string MessageKey { get; set; }
	[JsonPropertyName("messageKeyAlt")] public string MessageKeyAlt { get; set; }

	/// <inheritdoc />
	public string ToTranslatedString(Dictionary<string, string> localizationData)
	{
		return $"{Speaker}: {localizationData[MessageKey]}";
	}
}