using System.Text.Json.Serialization;
using SwgeChatbotParser.Model.Mission;

namespace SwgeChatbotParser.Model.Chat;

public class ChatVariableStep : Step
{
	[JsonPropertyName("speaker")] public ChatSpeaker Speaker { get; set; }
	[JsonPropertyName("messageKey")] public string MessageKey { get; set; }
	[JsonPropertyName("variableName")] public string VariableName { get; set; }
}