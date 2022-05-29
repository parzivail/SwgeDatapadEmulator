using System.Text.Json.Serialization;
using SwgeChatbotParser.Model.Mission;

namespace SwgeChatbotParser.Model.Rewards;

public class ItemRewardStep : Step
{
	[JsonPropertyName("itemId")] public string ItemId { get; set; }
	[JsonPropertyName("quantity")] public float Quantity { get; set; }
}