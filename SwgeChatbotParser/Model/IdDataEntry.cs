using System.Text.Json.Serialization;

namespace SwgeChatbotParser.Model;

public record IdDataEntry(
	[property: JsonPropertyName("id")] string Id
);