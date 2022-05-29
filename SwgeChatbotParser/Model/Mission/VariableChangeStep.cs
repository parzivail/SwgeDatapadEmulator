using System.Text.Json.Serialization;

namespace SwgeChatbotParser.Model.Mission;

public class VariableChangeStep : Step
{
	[JsonPropertyName("variableName")] public string VariableName { get; set; }
	[JsonPropertyName("changeAmount")] public float ChangeAmount { get; set; }
	[JsonPropertyName("set")] public bool ShouldSetValue { get; set; }

	/// <inheritdoc />
	public override string ToString()
	{
		return $"{VariableName} {(ShouldSetValue ? "" : "+")}= {ChangeAmount}";
	}
}