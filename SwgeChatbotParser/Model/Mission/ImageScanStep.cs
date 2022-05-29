﻿using System.Text.Json.Serialization;

namespace SwgeChatbotParser.Model.Steps;

public class ImageScanStep : Step
{
	[JsonPropertyName("difficulty")] public int Difficulty { get; set; }
	[JsonPropertyName("scrambled")] public bool scrambled { get; set; }
}