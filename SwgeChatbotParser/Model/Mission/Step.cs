using System.Text.Json.Serialization;

namespace SwgeChatbotParser.Model.Mission;

public class Step : Action
{
	[JsonPropertyName("locationIds")] public LocationId[] LocationIds { get; set; } = Array.Empty<LocationId>();
	[JsonPropertyName("mapDialogTitleKey")] public string MapDialogTitleKey { get; set; }
	[JsonPropertyName("mapDialogTitleKeyAlt")] public string MapDialogTitleKeyAlt { get; set; }
	[JsonPropertyName("mapDialogDescriptionKey")] public string MapDialogDescriptionKey { get; set; }
	[JsonPropertyName("mapDialogDescriptionKeyAlt")] public string MapDialogDescriptionKeyAlt { get; set; }
	[JsonPropertyName("mapDialogMissionChatOverride")] public string MapDialogMissionChatOverride { get; set; }
	[JsonPropertyName("isCheckpoint")] public bool IsCheckpoint { get; set; } = true;
	[JsonPropertyName("missionProgress")] public float MissionProgress { get; set; }
	[JsonPropertyName("incrementProgress")] public bool IncrementProgress { get; set; }
	[JsonPropertyName("progressParent")] public bool ProgressParent { get; set; }
	[JsonPropertyName("installationId")] public string InstallationId { get; set; }
	[JsonPropertyName("showIdToTrigger")] public string ShowIdToTrigger { get; set; }
}