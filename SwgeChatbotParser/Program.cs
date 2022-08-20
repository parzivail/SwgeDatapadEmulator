using System.Text;
using SwgeChatbotParser.Model;
using SwgeChatbotParser.Model.Chat;
using SwgeChatbotParser.Model.Mission;
using SwgeChatbotParser.Model.Rewards;
using Action = SwgeChatbotParser.Model.Action;

namespace SwgeChatbotParser;

public class Program
{
	public enum InstanceType
	{
		Temporary,
		Permanent,
		SessionData,
		Fixed,
		Count,
		HighestValue = 255
	}

	public static uint GetUserId(ulong aValue) => (uint)((aValue >> 32) & 0xFFFFFF);

	public static InstanceType GetType(ulong aValue) => (InstanceType)((aValue >> 56) & 0xFF);

	public static uint GetSerial(ulong aValue) => (uint)(aValue & 0xFFFFFFFF);

	public static ulong GetIid(InstanceType aType, uint aUserId, int aSerial)
	{
		return (ulong)(((long)aType << 56) + (long)((long)((ulong)aUserId) << 32) + (long)((ulong)aSerial));
	}

	public record Snowflake(InstanceType Type, uint User, uint Serial);

	public static void Main(string[] args)
	{
		var loader = new GameContentLoader(args[0], "starWarsGalaxysEdgeGame", "87");
		var chats = loader.GetChats();
		var missions = loader.GetMissions();

		foreach (var (key, data) in loader.GetInstallationData())
		{
			if (data.Type != "MidLevelGroupInstallation")
				continue;
			Console.WriteLine(data.Id);
			Console.WriteLine($"- {data.Name}");
			Console.WriteLine($"- {data.Description}");
			Console.WriteLine($"- {data.DlrThumbnailAltText}");
			Console.WriteLine($"- {data.DlrThumbnail}");
		}
		
		return;

		foreach (var (id, chat) in missions.OrderBy(pair => long.Parse(pair.Key)))
		{
			if (chat is ITranslatable translatable)
				Console.WriteLine(translatable.ToTranslatedString(loader.Localization));
			else
				Console.WriteLine(chat);
		}

		// var start = missions["72057886095713939"];
		//
		// Enter(start, loader.Localization, chats, missions);
	}

	private static HashSet<KeyValuePair<string, string>> TraversedKeys = new();

	private static string GetNodeId(Typed typed)
	{
		return $"N{typed.Id}_{(uint)typed.ToString().GetHashCode() % 1000}";
	}

	private static void Enter(Typed start, Dictionary<string, string> localizationData, Dictionary<string, Typed> chats, Dictionary<string, Typed> missions, int indentLevel = 0)
	{
		if (start is ITranslatable translatable)
			Console.WriteLine($"{GetNodeId(start)}[label=\"{translatable.ToTranslatedString(localizationData)}\"];");
		else
			Console.WriteLine($"{GetNodeId(start)}[label=\"{start}\"];");

		var (progressed, resolved) = ResolveLinks(start, chats, missions);
		var nextIndent = indentLevel + (progressed ? 4 : 1);

		foreach (var typed in resolved)
		{
			var pair = new KeyValuePair<string, string>(start.Id, typed.Id);
			if (TraversedKeys.Contains(pair))
				continue;
			TraversedKeys.Add(pair);

			Console.WriteLine($"{GetNodeId(start)} -> {GetNodeId(typed)};");

			Enter(typed, localizationData, chats, missions, nextIndent);
		}
	}

	private static (bool Progressed, Typed[] ResolvedLinks) ResolveLinks(Typed start, Dictionary<string, Typed> chats, Dictionary<string, Typed> missions)
	{
		switch (start)
		{
			case ChatStep chatMissionStep:
				return (false, new[] { chats[chatMissionStep.ChatId] });
			case Action action:
				return (true, action.LinkIds.Select(s => missions.ContainsKey(s) ? missions[s] : chats[s]).ToArray());
		}

		return (false, Array.Empty<Typed>());
	}
}