using System.Text.Json.Serialization;

namespace SwgeChatbotParser.Model.Mission;

public class SliceOfLifeStep : Step
{
	[JsonPropertyName("deeplink")] public DeepLink DeepLink { get; set; }
	[JsonPropertyName("scrambled")] public bool Scrambled { get; set; }
	[JsonPropertyName("transmissionIds")] public string[] TransmissionIds { get; set; } = Array.Empty<string>();
}