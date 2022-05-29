using System.Text.Json.Serialization;

namespace SwgeChatbotParser;

public record LocationId(
	[property: JsonPropertyName("locationId")] string Id,
	[property: JsonPropertyName("park")] Park Park
);