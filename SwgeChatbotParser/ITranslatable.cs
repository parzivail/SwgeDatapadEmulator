namespace SwgeChatbotParser;

public interface ITranslatable
{
	string ToTranslatedString(Dictionary<string, string> localizationData);
}