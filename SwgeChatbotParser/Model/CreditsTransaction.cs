using System.Text.Json.Serialization;

namespace SwgeChatbotParser.Model;

public record CreditsTransaction(
	[property: JsonPropertyName("value")] float Amount,
	[property: JsonPropertyName("displayInChat")] bool DisplayInChat,
	[property: JsonPropertyName("displayInDialog")] bool DisplayInDialog
);