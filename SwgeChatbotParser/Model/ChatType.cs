using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SwgeChatbotParser;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum ChatType
{
	[EnumMember(Value = "Mission")] Mission,
	[EnumMember(Value = "AudioTranslateStep")] AudioTranslateStep,
	[EnumMember(Value = "AutoEndMissionStep")] AutoEndMissionStep,
	[EnumMember(Value = "AutoStartMissionStep")] AutoStartMissionStep,
	[EnumMember(Value = "ChatStep")] ChatMissionStep,
	[EnumMember(Value = "DeviceHackStep")] DeviceHackStep,
	[EnumMember(Value = "DroidHackStep")] DroidHackStep,
	[EnumMember(Value = "ImageScanStep")] ImageScanStep,
	[EnumMember(Value = "ManifestStep")] ManifestStep,
	[EnumMember(Value = "MapLinkStep")] MapLinkStep,
	[EnumMember(Value = "NarrativeRewardStep")] NarrativeRewardStep,
	[EnumMember(Value = "SignalUnscrambleStep")] SignalUnscrambleStep,
	[EnumMember(Value = "SliceOfLifeStep")] SliceOfLifeStep,
	[EnumMember(Value = "TangramsStep")] TangramsStep,
	[EnumMember(Value = "TextTranslateStep")] TextTranslateStep,
	[EnumMember(Value = "TuneStep")] TuneStep,
	[EnumMember(Value = "VariableChangeStep")] VariableChangeStep,
	[EnumMember(Value = "CreditsRewardStep")] CreditsRewardStep,
	[EnumMember(Value = "FactionStandingRewardStep")] FactionStandingRewardStep,
	[EnumMember(Value = "GenericRewardStep")] GenericRewardStep,
	[EnumMember(Value = "ItemRewardStep")] ItemRewardStep,
	[EnumMember(Value = "MultiItemRewardStep")] MultiItemRewardStep,
	[EnumMember(Value = "BeaconProximityPrecondition")] BeaconProximityPrecondition,
	[EnumMember(Value = "CreditsPrecondition")] CreditsPrecondition,
	[EnumMember(Value = "MissionCompletePrecondition")] MissionCompletePrecondition,
	[EnumMember(Value = "OpsTogglePrecondition")] OpsTogglePrecondition,
	[EnumMember(Value = "ParkPrecondition")] ParkPrecondition,
	[EnumMember(Value = "SkimmersUnlockedPrecondition")] SkimmersUnlockedPrecondition,
	[EnumMember(Value = "StepCompletePrecondition")] StepCompletePrecondition,
	[EnumMember(Value = "TerritoryWarInProgressPrecondition")] TerritoryWarInProgressPrecondition,
	[EnumMember(Value = "UnstartablePrecondition")] UnstartablePrecondition,
	[EnumMember(Value = "VariableCheckPrecondition")] VariableCheckPrecondition,
	[EnumMember(Value = "ZonePrecondition")] ZonePrecondition,
}