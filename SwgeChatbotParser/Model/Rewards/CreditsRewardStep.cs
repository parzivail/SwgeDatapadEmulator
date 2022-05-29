using System.Text.Json.Serialization;
using SwgeChatbotParser.Model.Mission;

namespace SwgeChatbotParser.Model.Rewards;

public class CreditsRewardStep : Step
{
	[JsonPropertyName("amount")] public float Amount { get; set; }
}