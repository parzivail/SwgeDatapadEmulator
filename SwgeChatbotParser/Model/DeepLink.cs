﻿using System.Text.Json.Serialization;

namespace SwgeChatbotParser.Model;

public record DeepLink(
	[property: JsonPropertyName("enabled")] bool Enabled,
	[property: JsonPropertyName("directToActivity")] bool DirectToActivity,
	[property: JsonPropertyName("buttonText")] string ButtonTextKey
);