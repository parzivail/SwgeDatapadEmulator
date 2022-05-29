using System.Text.Json.Serialization;

namespace SwgeChatbotParser.Model.Mission;

public class AutoEndMissionStep : Step
{
	[JsonPropertyName("missionIdToEnd")] public string MissionIdToEnd { get; set; }
}