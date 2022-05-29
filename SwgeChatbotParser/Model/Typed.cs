using System.Text.Json.Serialization;

namespace SwgeChatbotParser.Model;

public class Typed
{
	[JsonPropertyName("id")] public string Id { get; set; }
	[JsonPropertyName("type")] public ChatType Type { get; set; }

	/// <inheritdoc />
	public override string ToString()
	{
		return $"{Type}";
	}
}