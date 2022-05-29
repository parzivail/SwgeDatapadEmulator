using System.Text.Json;
using System.Text.Json.Nodes;
using SwgeChatbotParser.Model;
using SwgeChatbotParser.Model.Chat;
using SwgeChatbotParser.Model.Mission;
using SwgeChatbotParser.Model.Preconditions;
using SwgeChatbotParser.Model.Rewards;

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
		// Preconditions
		MissionParsers[ChatType.UnstartablePrecondition] = CreateParser<UnstartablePrecondition>();
		MissionParsers[ChatType.MissionCompletePrecondition] = CreateParser<MissionCompletePrecondition>();
		MissionParsers[ChatType.CreditsPrecondition] = CreateParser<CreditsPrecondition>();
		MissionParsers[ChatType.StepCompletePrecondition] = CreateParser<StepCompletePrecondition>();
		MissionParsers[ChatType.VariableCheckPrecondition] = CreateParser<VariableCheckPrecondition>();
		MissionParsers[ChatType.BeaconProximityPrecondition] = CreateParser<BeaconProximityPrecondition>();
		MissionParsers[ChatType.OpsTogglePrecondition] = CreateParser<OpsTogglePrecondition>();
		MissionParsers[ChatType.SkimmersUnlockedPrecondition] = CreateParser<SkimmersUnlockedPrecondition>();
		MissionParsers[ChatType.TerritoryWarInProgressPrecondition] = CreateParser<TerritoryWarInProgressPrecondition>();
		MissionParsers[ChatType.ZonePrecondition] = CreateParser<ZonePrecondition>();
		MissionParsers[ChatType.ParkPrecondition] = CreateParser<ParkPrecondition>();
		
		// Actions
		MissionParsers[ChatType.Mission] = CreateParser<Mission>();
		MissionParsers[ChatType.DroidHackStep] = CreateParser<DroidHackStep>();
		MissionParsers[ChatType.ChatStep] = CreateParser<ChatStep>();
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
		
		// Chats
		MissionParsers[ChatType.Chat] = CreateParser<Chat>();
		MissionParsers[ChatType.ChatMessageStep] = CreateParser<ChatMessageStep>();
		MissionParsers[ChatType.ChatChooseStep] = CreateParser<ChatChooseStep>();
		MissionParsers[ChatType.ChatDecisionStep] = CreateParser<ChatDecisionStep>();
		MissionParsers[ChatType.ChatMapLinkStep] = CreateParser<ChatMapLinkStep>();
		MissionParsers[ChatType.ChatImageStep] = CreateParser<ChatImageStep>();
		MissionParsers[ChatType.ChatDeeplinkStep] = CreateParser<ChatDeeplinkStep>();
		MissionParsers[ChatType.ChatPlayerSwitchStep] = CreateParser<ChatPlayerSwitchStep>();
		MissionParsers[ChatType.ChatVariableStep] = CreateParser<ChatVariableStep>();
		MissionParsers[ChatType.ChatNewStateLinkStep] = CreateParser<ChatNewStateLinkStep>();
		MissionParsers[ChatType.ChatShowTransmission] = CreateParser<ChatShowTransmissionStep>();
		MissionParsers[ChatType.ToolLaunchStep] = CreateParser<ToolLaunchStep>();
		MissionParsers[ChatType.BlockingChatButtonStep] = CreateParser<BlockingChatButtonStep>();
		MissionParsers[ChatType.DisambigLaunchStep] = CreateParser<DisambigLaunchStep>();
		MissionParsers[ChatType.MissionEndStep] = CreateParser<MissionEndStep>();
		MissionParsers[ChatType.ChatToastTextStep] = CreateParser<ChatToastTextStep>();
	}

	private static ParseDelegate CreateParser<T>() where T : Typed
	{
		return json => json.Deserialize<T>() ?? throw new InvalidDataException($"Unable to parse {typeof(T)}");
	}
}