using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SwgeChatbotParser.Model;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum ChatSpeaker
{
	[EnumMember(Value = "NONE")] None,
	[EnumMember(Value = "PLAYER")] Player,
	[EnumMember(Value = "MISSION_GIVER")] MissionGiver
}