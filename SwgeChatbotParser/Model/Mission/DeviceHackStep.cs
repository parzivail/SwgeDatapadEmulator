using System.Text.Json.Serialization;

namespace SwgeChatbotParser.Model.Mission;

public class DeviceHackStep : Step
{
	[JsonPropertyName("deviceName")] public string DeviceName { get; set; }
	[JsonPropertyName("difficulty")] public int Difficulty { get; set; }
}