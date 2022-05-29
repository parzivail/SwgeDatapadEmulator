using System.Text.Json.Serialization;
using SwgeChatbotParser.Model.Mission;

namespace SwgeChatbotParser.Model.Chat;

public class ChatDecisionStep : Step, ITranslatable
{
	[JsonPropertyName("messageKey")] public string MessageKey { get; set; }

	/// <inheritdoc />
	public string ToTranslatedString(Dictionary<string, string> localizationData)
	{
		return $"<Choice> {localizationData[MessageKey]}";
	}
}