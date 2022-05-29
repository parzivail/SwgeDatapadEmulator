using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SwgeChatbotParser;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum Park
{
	[EnumMember(Value = "wdw")] WaltDisneyWorld,
	[EnumMember(Value = "dlr")] DisneylandResort,
}