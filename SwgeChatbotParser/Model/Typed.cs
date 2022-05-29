using System.Text.Json.Serialization;

namespace SwgeChatbotParser;

public class Typed
{
	[JsonPropertyName("id")] public string Id { get; set; }
	[JsonPropertyName("type")] public ChatType Type { get; set; }
}