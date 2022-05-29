using System.Text.Json.Serialization;

namespace SwgeChatbotParser.Model.Mission;

public class ChatStep : Step
{
	[JsonPropertyName("chatId")] public string ChatId { get; set; }

	/// <inheritdoc />
	public override string ToString()
	{
		return $"Mission {Id} to Chat {ChatId}";
	}
}