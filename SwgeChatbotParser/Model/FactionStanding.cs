using System.Text.Json.Serialization;

namespace SwgeChatbotParser;

public record FactionStanding(
	[property: JsonPropertyName("faction")] Faction Faction,
	[property: JsonPropertyName("value")] float Value,
	[property: JsonPropertyName("displayInChat")] bool DisplayInChat,
	[property: JsonPropertyName("displayInDialog")] bool DisplayInDialog
);