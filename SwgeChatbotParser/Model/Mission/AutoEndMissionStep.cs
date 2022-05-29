using System.Text.Json.Serialization;

namespace SwgeChatbotParser.Model.Steps;

public class AutoEndMissionStep : Step
{
	[JsonPropertyName("missionIdToEnd")] public string MissionIdToEnd { get; set; }
}