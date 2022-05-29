using System.Text.Json;
using System.Text.Json.Nodes;

namespace SwgeChatbotParser;

public class GameContentLoader
{
	private Dictionary<string, string>? _localizationData;
	public Dictionary<string, string> Localization => _localizationData ??= GetLocalizationData();

	public string ContentRoot { get; }
	public string GameBaseName { get; }
	public string ContentVersion { get; }

	public GameContentLoader(string contentRoot, string gameBaseName, string contentVersion)
	{
		ContentRoot = contentRoot;
		GameBaseName = gameBaseName;
		ContentVersion = contentVersion;
	}

	private string GetFilename(string contentId)
	{
		return Path.Combine(ContentRoot, $"{GameBaseName}_{ContentVersion}_{contentId}.json");
	}

	public T[] GetGameContent<T>(string contentId)
	{
		var filename = GetFilename(contentId);
		var data = JsonSerializer.Deserialize<Dictionary<string, T>>(File.ReadAllText(filename));
		if (data == null)
			throw new InvalidDataException("Unable to parse firebase-db JSON");
		return data.Values.ToArray();
	}

	public Dictionary<string, KeyValuePair<Typed, JsonObject>> GetMissions()
	{
		var entries = GetGameContent<JsonObject>("mission-data");
		return entries
			.Select(o => new KeyValuePair<Typed, JsonObject>(o.Deserialize<Typed>() ?? throw new InvalidDataException("Data did not extend Typed"), o))
			.ToDictionary(
				data => data.Key.Id ?? throw new InvalidDataException("Typed did not have ID"),
				data => data
			);
	}

	public Dictionary<string, ContactData> GetContactData()
	{
		var entries = GetGameContent<ContactDataEntry>("contact-data");
		return entries
			.Select(entry => new ContactData(entry.Id, entry.Faction, Localization[entry.NameKey]))
			.ToDictionary(data => data.Id, data => data);
	}

	private Dictionary<string, string> GetLocalizationData()
	{
		var pageCountEntries = GetGameContent<Dictionary<string, int>>("page-counts");
		var pageCounts = pageCountEntries[0];

		var localizationData = new Dictionary<string, string>();

		for (var i = 0; i < pageCounts["lang/generated-en"]; i++)
		{
			var pageContentId = $"generated-en-{i}";
			var localizationPageEntries = GetGameContent<Dictionary<string, string>>(pageContentId);
			var localizationPage = localizationPageEntries[0];

			localizationData.AddRange(localizationPage);
		}

		for (var i = 0; i < pageCounts["lang/en"]; i++)
		{
			var pageContentId = $"en-{i}";
			var localizationPageEntries = GetGameContent<JsonElement>(pageContentId);
			var localizationPage = localizationPageEntries[0];

			ParseNestedLocalizationData(localizationData, localizationPage);
		}

		return localizationData;
	}

	private static void ParseNestedLocalizationData(Dictionary<string, string> localizationData, JsonElement page, string? root = null)
	{
		switch (page.ValueKind)
		{
			case JsonValueKind.Object:
			{
				foreach (var child in page.EnumerateObject())
					ParseNestedLocalizationData(localizationData, child.Value, root == null ? child.Name : (root + "." + child.Name));
				break;
			}
			case JsonValueKind.String when root == null:
				throw new ArgumentException("Cannot add translation for null key", nameof(root));
			case JsonValueKind.String:
				localizationData[root] = page.GetString() ?? throw new ArgumentException("Cannot add null translation", nameof(page));
				break;
			default:
				throw new ArgumentException("Invalid translation property value", nameof(page));
		}
	}
}