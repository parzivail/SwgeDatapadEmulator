using System.Text.Json.Serialization;

namespace SwgeChatbotParser.Model.Steps;

public class AutoStartMissionStep : Step
{
	[JsonPropertyName("missionIdToStart")] public string MissionIdToStart { get; set; }
}