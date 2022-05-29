using System.Text.Json;
using System.Text.Json.Nodes;

namespace SwgeChatbotParser;

public class ChatParser
{
	private delegate Typed ParseDelegate(JsonObject json);

	private static readonly Dictionary<ChatType, ParseDelegate> MissionParsers = new();

	public static Typed Parse(ChatType type, JsonObject json)
	{
		if (MissionParsers.TryGetValue(type, out var function))
			return function.Invoke(json);

		throw new ArgumentException($"No parser registered for type {type}", nameof(type));
	}

	static ChatParser()
	{
		// Actions
		MissionParsers[ChatType.Mission] = CreateParser<Mission>();
		MissionParsers[ChatType.DroidHackStep] = CreateParser<DroidHackStep>();
		MissionParsers[ChatType.ChatMissionStep] = CreateParser<ChatMissionStep>();
		MissionParsers[ChatType.DeviceHackStep] = CreateParser<DeviceHackStep>();
		MissionParsers[ChatType.TuneStep] = CreateParser<TuneStep>();
		MissionParsers[ChatType.SignalUnscrambleStep] = CreateParser<SignalUnscrambleStep>();
		MissionParsers[ChatType.TangramsStep] = CreateParser<TangramsStep>();
		MissionParsers[ChatType.TextTranslateStep] = CreateParser<TextTranslateStep>();
		MissionParsers[ChatType.AudioTranslateStep] = CreateParser<AudioTranslateStep>();
		MissionParsers[ChatType.ImageScanStep] = CreateParser<ImageScanStep>();
		MissionParsers[ChatType.NarrativeRewardStep] = CreateParser<NarrativeRewardStep>();
		MissionParsers[ChatType.ManifestStep] = CreateParser<ManifestStep>();
		MissionParsers[ChatType.CreditsRewardStep] = CreateParser<CreditsRewardStep>();
		MissionParsers[ChatType.FactionStandingRewardStep] = CreateParser<FactionStandingRewardStep>();
		MissionParsers[ChatType.GenericRewardStep] = CreateParser<GenericRewardStep>();
		MissionParsers[ChatType.ItemRewardStep] = CreateParser<ItemRewardStep>();
		MissionParsers[ChatType.MultiItemRewardStep] = CreateParser<MultiItemRewardStep>();
		MissionParsers[ChatType.AutoStartMissionStep] = CreateParser<AutoStartMissionStep>();
		MissionParsers[ChatType.AutoEndMissionStep] = CreateParser<AutoEndMissionStep>();
		MissionParsers[ChatType.SliceOfLifeStep] = CreateParser<SliceOfLifeStep>();
		MissionParsers[ChatType.VariableChangeStep] = CreateParser<VariableChangeStep>();
		MissionParsers[ChatType.MapLinkStep] = CreateParser<MapLinkStep>();
		
		// Preconditions
		MissionParsers[ChatType.MapLinkStep] = CreateParser<MapLinkStep>();
	}

	private static ParseDelegate CreateParser<T>() where T : Typed
	{
		return json => json.Deserialize<T>() ?? throw new InvalidDataException($"Unable to parse {typeof(T)}");
	}
}