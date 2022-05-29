using System.Text.Json.Serialization;

namespace SwgeChatbotParser.Model.Preconditions;

public class Precondition : Typed
{
	[JsonPropertyName("negate")] public bool Negate { get; set; }
	[JsonPropertyName("canBypass")] public bool CanBypass { get; set; }
	[JsonPropertyName("evaluateOnStartedJobs")] public bool EvaluateOnStartedJobs { get; set; }
}

public class UnstartablePrecondition : Precondition
{
}

public class SkimmersUnlockedPrecondition : Precondition
{
}

public class TerritoryWarInProgressPrecondition : Precondition
{
}

public class MissionCompletePrecondition : Precondition
{
	[JsonPropertyName("missionId")] public string MissionId { get; set; }
}

public class ZonePrecondition : Precondition
{
	[JsonPropertyName("zoneLabel")] public string ZoneLabel { get; set; }
}

public class ParkPrecondition : Precondition
{
	[JsonPropertyName("park")] public Park Park { get; set; }
}

public class StepCompletePrecondition : Precondition
{
	[JsonPropertyName("stepId")] public string StepId { get; set; }
}

public class CreditsPrecondition : Precondition
{
	[JsonPropertyName("credits")] public float Credits { get; set; }
}

public class BeaconProximityPrecondition : Precondition
{
	[JsonPropertyName("beaconIds")] public string[] BeaconIds { get; set; } = Array.Empty<string>();
}

public class OpsTogglePrecondition : Precondition
{
	[JsonPropertyName("toggle")] public string OpToggleId { get; set; }
}

public class VariableCheckPrecondition : Precondition
{
	[JsonPropertyName("variableName")] public string VariableName { get; set; }
	[JsonPropertyName("value")] public float Value { get; set; }
	[JsonPropertyName("condition")] public VariableCondition Condition { get; set; }
}