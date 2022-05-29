using System.Text.Json.Serialization;

namespace SwgeChatbotParser.Model;

public class Action : Typed
{
	[JsonPropertyName("linkIds")] public string[] LinkIds { get; set; }
	[JsonPropertyName("preconditionIds")] public string[] PreconditionIds { get; set; }
}