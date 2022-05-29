using System.Text.Json.Serialization;

namespace SwgeChatbotParser.Model.Mission;

public class AutoStartMissionStep : Step
{
	[JsonPropertyName("missionIdToStart")] public string MissionIdToStart { get; set; }
}