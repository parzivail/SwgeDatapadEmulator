using System.Text.Json.Serialization;

namespace SwgeChatbotParser.Model;

public record InstallationDataEntry(
	string Id,
	[property: JsonPropertyName("type")] string Type,
	[property: JsonPropertyName("dlr_thumbnailPath")] string DlrThumbnail,
	[property: JsonPropertyName("dlr_thumbnailAltText")] string DlrThumbnailAltText,
	[property: JsonPropertyName("wdw_thumbnailPath")] string WdwThumbnail,
	[property: JsonPropertyName("wdw_thumbnailAltText")] string WdwThumbnailAltText,
	[property: JsonPropertyName("nameKey")] string NameKey,
	[property: JsonPropertyName("descriptionKey")] string DescKey
) : IdDataEntry(Id);