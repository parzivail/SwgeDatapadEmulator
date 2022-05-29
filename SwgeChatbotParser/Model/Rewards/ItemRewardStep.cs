using System.Text.Json.Serialization;

namespace SwgeChatbotParser;

public class ItemRewardStep : Step
{
	[JsonPropertyName("itemId")] public string ItemId { get; set; }
	[JsonPropertyName("quantity")] public float Quantity { get; set; }
}