namespace SwgeChatbotParser;

public static class DictionaryExt
{
	public static void AddRange<TK, TV>(this Dictionary<TK, TV> dest, Dictionary<TK, TV> src) where TK : notnull
	{
		foreach (var (k, v) in src)
			dest.Add(k, v);
	}
}