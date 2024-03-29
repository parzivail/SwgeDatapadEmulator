﻿using System.Text.Json.Serialization;
using SwgeChatbotParser.Model.Mission;

namespace SwgeChatbotParser.Model.Chat;

public class ChatPlayerSwitchStep : Step
{
	[JsonPropertyName("messageKey")] public string MessageKey { get; set; }
}