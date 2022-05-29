using System.Text.Json.Serialization;
using SwgeChatbotParser.Model.Mission;

namespace SwgeChatbotParser.Model.Chat;

public class ChatMapLinkStep : Step
{
	[JsonPropertyName("jobsFilterActive")] public bool JobsFilterActive { get; set; }
	[JsonPropertyName("toolsFilterActive")] public bool ToolsFilterActive { get; set; }
	[JsonPropertyName("labelsFilterActive")] public bool LabelsFilterActive { get; set; }
	[JsonPropertyName("territoryWarFilterActive")] public bool TerritoryWarFilterActive { get; set; }
}