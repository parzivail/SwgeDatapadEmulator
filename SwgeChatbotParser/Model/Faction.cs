using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SwgeChatbotParser.Model;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum Faction
{
	[EnumMember(Value = "re")] Resistance,
	[EnumMember(Value = "fo")] FirstOrder,
	[EnumMember(Value = "sm")] Smuggler,
	[EnumMember(Value = "ne")] Neutral,
	[EnumMember(Value = "fc")] Force
}