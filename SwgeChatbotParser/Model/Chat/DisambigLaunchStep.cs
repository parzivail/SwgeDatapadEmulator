using System.Text.Json.Serialization;
using SwgeChatbotParser.Model.Mission;

namespace SwgeChatbotParser.Model.Chat;

public class DisambigLaunchStep : Step
{
	[JsonPropertyName("disambigToLaunch")] public string DisambigToLaunch { get; set; }
	[JsonPropertyName("installations")] public string[] Installations { get; set; } = Array.Empty<string>();
	[JsonPropertyName("buttonText")] public string ButtonTextKey { get; set; }
}