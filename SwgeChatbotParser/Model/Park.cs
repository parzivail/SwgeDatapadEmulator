using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SwgeChatbotParser.Model;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum Park
{
	[EnumMember(Value = "wdw")] WaltDisneyWorld,
	[EnumMember(Value = "dlr")] DisneylandResort,
	[EnumMember(Value = "swgs_deck4a")] GalacticStarcruiserDeck4A,
	[EnumMember(Value = "swgs_deck4f")] GalacticStarcruiserDeck4F,
	[EnumMember(Value = "swgs_deck5")] GalacticStarcruiserDeck5,
	[EnumMember(Value = "swgs_deck6")] GalacticStarcruiserDeck6,
	[EnumMember(Value = "swgs_deck7")] GalacticStarcruiserDeck7,
}

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum VariableCondition
{
	[EnumMember(Value = "GreaterThanOrEqualTo")] GreaterEqual,
	[EnumMember(Value = "LessThanOrEqualTo")] LessEqual,
	[EnumMember(Value = "GreaterThan")] Greater,
	[EnumMember(Value = "LessThan")] Less,
	[EnumMember(Value = "EqualTo")] Equal,
}