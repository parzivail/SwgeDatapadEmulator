using System.Text.Json.Serialization;
using SwgeChatbotParser.Model.Mission;

namespace SwgeChatbotParser.Model.Chat;

public class ToolLaunchStep : Step
{
	[JsonPropertyName("toolToLaunch")] public string ToolToLaunch { get; set; }
	[JsonPropertyName("buttonText")] public string ButtonTextKey { get; set; }
}