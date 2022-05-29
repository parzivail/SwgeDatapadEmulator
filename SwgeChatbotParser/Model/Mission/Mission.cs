using System.Text.Json.Serialization;

namespace SwgeChatbotParser.Model.Steps;

public class Mission : Action
{
	[JsonPropertyName("parentMissionId")] public string ParentMissionId { get; set; }
	[JsonPropertyName("name")] public string Name { get; set; }
	[JsonPropertyName("title")] public string TitleKey { get; set; }
	[JsonPropertyName("description")] public string DescriptionKey { get; set; }
	[JsonPropertyName("contactId")] public string ContactId { get; set; }
	[JsonPropertyName("listed")] public bool Listed { get; set; }
	[JsonPropertyName("swgsChatSequence")] public bool SwgsChatSequence { get; set; }
	[JsonPropertyName("swgsBotSequence")] public bool SwgsBotSequence { get; set; }
	[JsonPropertyName("faction")] public Faction Faction { get; set; }
	[JsonPropertyName("advertisedCreditReward")] public int? AdvertisedCreditReward { get; set; }
	[JsonPropertyName("potentialRewardsIds")] public string[] PotentialRewardsIds { get; set; } = Array.Empty<string>();
	[JsonPropertyName("preconditionDescription")] public string PreconditionDescriptionKey { get; set; }
	[JsonPropertyName("variablesToReset")] public string[] VariablesToReset { get; set; } = Array.Empty<string>();
	[JsonPropertyName("playDeepLinkIds")] public string[] PlayDeepLinkIds { get; set; } = Array.Empty<string>();
	[JsonPropertyName("location")] public string LocationKey { get; set; }
	[JsonPropertyName("imagePath")] public string ImagePath { get; set; }
	[JsonPropertyName("listPriority")] public int ListPriority { get; set; }
	[JsonPropertyName("resetOnParkChange")] public bool ResetOnParkChange { get; set; }
}