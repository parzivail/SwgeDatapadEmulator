using System.Text.Json.Serialization;

namespace SwgeChatbotParser;

public record ContactDataEntry(
	[property: JsonPropertyName("id")] string Id,
	[property: JsonPropertyName("faction")] Faction Faction,
	[property: JsonPropertyName("name")] string NameKey,
	[property: JsonPropertyName("imageKey")] string ImageKey,
	[property: JsonPropertyName("imagePath")] string ImagePath,
	[property: JsonPropertyName("exportContact")] bool Export
);