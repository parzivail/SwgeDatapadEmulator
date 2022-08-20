using System.Text.Json;
using System.Text.Json.Nodes;
using SwgeChatbotParser.Model;

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

	public Dictionary<string, Typed> GetMissions()
	{
		return GetTypedData("mission-data");
	}

	public Dictionary<string, Typed> GetChats()
	{
		return GetTypedData("chat-data");
	}

	private Dictionary<string, Typed> GetTypedData(string key)
	{
		var entries = GetGameContent<JsonObject>(key);
		return entries
			.Select(o => ChatParser.Parse((o.Deserialize<Typed>() ?? throw new InvalidDataException("Data did not extend Typed")).Type, o))
			.ToDictionary(
				data => data.Id ?? throw new InvalidDataException("Typed did not have ID"),
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

	public Dictionary<string, IdData> GetItemData()
	{
		var entries = GetGameContent<IdDataEntry>("item-data");
		return entries
			.Select(entry => new IdData(entry.Id))
			.ToDictionary(data => data.Id, data => data);
	}

	public Dictionary<string, IdData> GetBeaconData()
	{
		var entries = GetGameContent<IdDataEntry>("beacon-data");
		return entries
			.Select(entry => new IdData(entry.Id))
			.ToDictionary(data => data.Id, data => data);
	}

	public Dictionary<string, IdData> GetAchievementData()
	{
		var entries = GetGameContent<IdDataEntry>("achievement-data");
		return entries
			.Select(entry => new IdData(entry.Id))
			.ToDictionary(data => data.Id, data => data);
	}

	public Dictionary<string, IdData> GetAudioTranslateShowData()
	{
		var entries = GetGameContent<IdDataEntry>("audio-translate-show-data");
		return entries
			.Select(entry => new IdData(entry.Id))
			.ToDictionary(data => data.Id, data => data);
	}

	public Dictionary<string, IdData> GetImageMarkerData()
	{
		var entries = GetGameContent<IdDataEntry>("image-marker-data");
		return entries
			.Select(entry => new IdData(entry.Id))
			.ToDictionary(data => data.Id, data => data);
	}

	public Dictionary<string, InstallationData> GetInstallationData()
	{
		var entries = GetGameContent<InstallationDataEntry>("installation-data");
		return entries
			.Select(entry => new InstallationData(entry.Id, Localization[entry.NameKey], Localization[entry.DescKey], entry.Type, entry.DlrThumbnail, entry.DlrThumbnailAltText, entry.WdwThumbnail, entry.WdwThumbnailAltText))
			.ToDictionary(data => data.Id, data => data);
	}

	public Dictionary<string, IdData> GetMapData(MapLocation location)
	{
		var entries = GetGameContent<IdDataEntry>("map-location-data-" + location.Filename);
		return entries
			.Select(entry => new IdData(entry.Id))
			.ToDictionary(data => data.Id, data => data);
	}

	public Dictionary<string, IdData> GetMapObjectData(MapLocation location)
	{
		var entries = GetGameContent<IdDataEntry>("map-object-data-" + location.Filename);
		return entries
			.Select(entry => new IdData(entry.Id))
			.ToDictionary(data => data.Id, data => data);
	}

	public Dictionary<string, IdData> GetPushNotificationData()
	{
		var entries = GetGameContent<IdDataEntry>("push-notification-data");
		return entries
			.Select(entry => new IdData(entry.Id))
			.ToDictionary(data => data.Id, data => data);
	}

	public Dictionary<string, IdData> GetStarMapRegionData()
	{
		var entries = GetGameContent<IdDataEntry>("star-map-region-data");
		return entries
			.Select(entry => new IdData(entry.Id))
			.ToDictionary(data => data.Id, data => data);
	}

	public Dictionary<string, IdData> GetTextMarkerData()
	{
		var entries = GetGameContent<IdDataEntry>("text-marker-data");
		return entries
			.Select(entry => new IdData(entry.Id))
			.ToDictionary(data => data.Id, data => data);
	}

	public Dictionary<string, IdData> GetTriggerableShowData()
	{
		var entries = GetGameContent<IdDataEntry>("triggerable-show-data");
		return entries
			.Select(entry => new IdData(entry.Id))
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

		localizationData[""] = "<No Localization>";

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