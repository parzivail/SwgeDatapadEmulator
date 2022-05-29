using System.Text.Json.Serialization;

namespace SwgeChatbotParser;

public class CreditsRewardStep : Step
{
	[JsonPropertyName("amount")] public float Amount { get; set; }
}