namespace SwgeChatbotParser.Model;

public record InstallationData(
	string Id,
	string Name,
	string Description,
	string Type,
	string DlrThumbnail,
	string DlrThumbnailAltText,
	string WdwThumbnail,
	string WdwThumbnailAltText
) : IdData(Id);