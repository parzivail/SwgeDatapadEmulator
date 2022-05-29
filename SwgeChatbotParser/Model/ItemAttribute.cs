using System.Text.Json.Serialization;

namespace SwgeChatbotParser.Model;

public record ItemAttribute(
	[property: JsonPropertyName("key")] string NameKey,
	[property: JsonPropertyName("value")] string ValueKey
);