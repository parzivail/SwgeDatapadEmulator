using System.Net;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using WebSocketSharp;
using WebSocketSharp.Net;
using WebSocketSharp.Server;
using ErrorEventArgs = WebSocketSharp.ErrorEventArgs;

namespace SwgeDatapadEmulator;

public record DatapadRequest(
	[property: JsonPropertyName("reqId")] int Id,
	[property: JsonPropertyName("type")] string Type,
	[property: JsonPropertyName("command")] string Command,
	[property: JsonPropertyName("payload")] JsonObject Data
);

public record DatapadResponse(
	[property: JsonPropertyName("requestID")] int Id,
	[property: JsonPropertyName("status")] string Status,
	[property: JsonPropertyName("payload")] object Data
);

public record DatapadGetGameContentPayload(
	[property: JsonPropertyName("contentId")] string ContentId,
	[property: JsonPropertyName("contentVersionId")] string ContentVersion
);

public record DatapadGameInitPayload(
	[property: JsonPropertyName("debug")] bool Debug,
	[property: JsonPropertyName("isBluetoothSharingEnabled")] bool IsBluetoothSharingEnabled,
	[property: JsonPropertyName("isLowPowerModeEnabled")] bool IsLowPowerModeEnabled,
	[property: JsonPropertyName("playerLocation")] string PlayerLocation,
	[property: JsonPropertyName("playerInfoRead")] DatapadPlayerInfoRead PlayerInfoRead,
	[property: JsonPropertyName("gameDefinitionRead")] DatapadGameDefinitionRead GameDefinitionRead,
	[property: JsonPropertyName("selectedParty")] DatapadPlayer[] SelectedParty
);

public record DatapadEntitlement(
	[property: JsonPropertyName("id")] string Id,
	[property: JsonPropertyName("startDateTime")] DateTime StartDateTime,
	[property: JsonPropertyName("endDateTime")] DateTime EndDateTime
);

public record DatapadGameModeConfiguration(
	[property: JsonPropertyName("duringReservation")] bool DuringReservation,
	[property: JsonPropertyName("preArrival")] bool PreArrival,
	[property: JsonPropertyName("isGuestOnShip")] bool IsGuestOnShip,
	[property: JsonPropertyName("isGuestOnPlanet")] bool IsGuestOnPlanet
);

public record DatapadGameDefinitionRead(
	[property: JsonPropertyName("title")] string Title,
	[property: JsonPropertyName("identifier")] string Identifier
);

public record DatapadPlayer(
	[property: JsonPropertyName("name")] string Name,
	[property: JsonPropertyName("identifier")] string Identifier
);

public record DatapadAssetPayload(
	[property: JsonPropertyName("assetIds")] string[] AssetIds
);

public record DatapadAgendaPayload(
	[property: JsonPropertyName("entitlementId")] string EntitlementId
);

public record DatapadAgendaResponsePayload(
	[property: JsonPropertyName("agendaRetrievedAt")] string EntitlementId,
	[property: JsonPropertyName("agenda")] DatapadAgendaEntry[] Agenda
);

public record DatapadAgendaEntry(
	[property: JsonPropertyName("id")] string Id,
	[property: JsonPropertyName("displayName")] string DisplayName,
	[property: JsonPropertyName("subtitle")] string Subtitle,
	[property: JsonPropertyName("description")] string Description,
	[property: JsonPropertyName("startTime")] DateTime StartTime,
	[property: JsonPropertyName("endTime")] DateTime EndTime,
	[property: JsonPropertyName("location")] string Location,
	[property: JsonPropertyName("isHighlighted")] bool IsHighlighted,
	[property: JsonPropertyName("isInvited")] bool IsInvited,
	[property: JsonPropertyName("isShoreExcursion")] bool IsShoreExcursion,
	[property: JsonPropertyName("filters")] string Filters,
	[property: JsonPropertyName("characterID")] string CharacterId
);

public record DatapadExternalDataPayload(
	[property: JsonPropertyName("gameMode")] string GameMode,
	[property: JsonPropertyName("entitlementId")] string EntitlementId
);

public record DatapadExternalData(
	[property: JsonPropertyName("data")] DatapadExternalDataObject[] Data
);

public record DatapadExternalDataObject(
	[property: JsonPropertyName("id")] string Id
);

public record DatapadPlayerInfoRead(
	[property: JsonPropertyName("playerInfo")] DatapadPlayerInfo ContentId
);

public record DatapadPlayerInfo(
	[property: JsonPropertyName("swid")] string Swid,
	[property: JsonPropertyName("isLoggedIn")] bool IsLoggedIn
);

public record DatapadDataPayload(
	[property: JsonPropertyName("data")] object Data
);

public record DatapadErrorPayload(
	[property: JsonPropertyName("error")] string Error
);

public class DatapadWsInterop : WebSocketBehavior
{
	private string FirestoreDbPath = Environment.GetEnvironmentVariable("DATAPAD_FIRESTOREDB_PATH");
	private const string GameId = "starWarsGalaxysEdgeGame";
	private const string SuccessStatus = "SUCCESS";
	private const string ErrorStatus = "ERROR";

	/// <inheritdoc />
	protected override void OnMessage(MessageEventArgs e)
	{
		Console.WriteLine(e.Data);
		var request = JsonSerializer.Deserialize<DatapadRequest>(e.Data);
		Lumberjack.Logger.Info($"Request: ID={request.Id}, Type={request.Type}, Command={request.Command}");

		var (status, payload) = request.Command switch
		{
			"GET_GAME_CONTENT" => GetGameContent(request.Data),
			"GAME_INIT" => (SuccessStatus, new DatapadGameInitPayload(
				true, true, false,
				"waltDisneyWorld",
				new DatapadPlayerInfoRead(new DatapadPlayerInfo("123456789ABCDEF", true)),
				new DatapadGameDefinitionRead("swgs", "swgs"),
				new[] { new DatapadPlayer("parzivail", "123456789ABCDEF") }
			)),
			"GET_CURRENT_ENTITLEMENT" => (SuccessStatus, new DatapadEntitlement("swgs", DateTime.Now - TimeSpan.FromDays(1), DateTime.Now + TimeSpan.FromDays(1))),
			"GET_GAME_MODE_CONFIGURATION" => (SuccessStatus, new DatapadGameModeConfiguration(true, false, false, true)),
			"CAMERA_ACCESS_STATUS" => (SuccessStatus, 3),
			"START_CAMERA" => (SuccessStatus, true),
			"END_CAMERA" => (SuccessStatus, true),
			"AR_SESSION_AVAILABLE" => (SuccessStatus, true),
			"GET_AGENDA" => GetAgenda(request.Data),
			"ASSETS" => GetAsset(request.Data),
			"GET_GAME_DATA_FROM_EXTERNAL_SOURCE" => GetExternalGameData(request.Data),
			_ => (null, null)
		};

		if (status != null)
			Send(JsonSerializer.Serialize(new DatapadResponse(request.Id, status, payload)));
	}

	private (string Status, object Payload) GetAsset(JsonObject requestData)
	{
		var payload = requestData.Deserialize<DatapadAssetPayload>();
		return (SuccessStatus, null);
	}

	private (string Status, object Payload) GetAgenda(JsonObject requestData)
	{
		var payload = requestData.Deserialize<DatapadAgendaPayload>();
		return (SuccessStatus, new DatapadAgendaResponsePayload("swgs", new[]
		{
			new DatapadAgendaEntry(
				"1234", "Agenda AAAA", "Subtitle", "Wot",
				DateTime.Now, DateTime.Now + TimeSpan.FromHours(1),
				"Locate",
				false, false, false,
				"All,My Events",
				""
			)
		}));
	}

	private (string Status, object Payload) GetExternalGameData(JsonObject requestData)
	{
		var payload = requestData.Deserialize<DatapadExternalDataPayload>();
		return (SuccessStatus, new DatapadExternalData(new[] { new DatapadExternalDataObject("abc123") }));
	}

	private (string Status, object Payload) GetGameContent(JsonNode requestData)
	{
		var payload = requestData.Deserialize<DatapadGetGameContentPayload>();
		var searchPath = Path.Combine(FirestoreDbPath, $"{GameId}_{payload.ContentVersion}_{payload.ContentId}.json");
		if (!File.Exists(searchPath))
			return (ErrorStatus, new DatapadErrorPayload("File Not Found"));

		Lumberjack.Logger.Info($"Loaded file {searchPath}");

		return (SuccessStatus, new DatapadDataPayload(JsonSerializer.Deserialize<Dictionary<string, JsonObject>>(File.ReadAllText(searchPath)).Values));
	}
}

public class DatapadLogger : WebSocketBehavior
{
	/// <inheritdoc />
	protected override void OnOpen()
	{
		Program.DataWriter.Write(DateTime.UtcNow.Ticks);
		Program.DataWriter.Write((byte)Program.Opcode.Connect);
	}

	/// <inheritdoc />
	protected override void OnMessage(MessageEventArgs e)
	{
		Console.WriteLine(e.Data.Length > 128 ? e.Data[..128] : e.Data);
		// Program.OutFile.Write(Encoding.UTF8.GetBytes(e.Data));
		// Program.OutFile.WriteByte((byte)'\n');
		
		Program.DataWriter.Write(DateTime.UtcNow.Ticks);
		Program.DataWriter.Write((byte)Program.Opcode.Data);
		Program.DataWriter.Write(e.Data);
	}

	/// <inheritdoc />
	protected override void OnClose(CloseEventArgs e)
	{
		Program.DataWriter.Write(DateTime.UtcNow.Ticks);
		Program.DataWriter.Write((byte)Program.Opcode.Disconnect);
	}
}

public class Program
{
	// public static FileStream OutFile;
	public static ManualResetEventSlim ExitHandle;
	
	public enum Opcode : byte
	{
		Connect = 0x01,
		Data = 0x02,
		Disconnect = 0x03
	}

	private static readonly FileStream _outStream;
	public static readonly BinaryWriter DataWriter;

	static Program()
	{
		var outFile = $"log-{DateTime.UtcNow.Ticks}.bin";
		_outStream = new FileStream(outFile, FileMode.Create, FileAccess.Write, FileShare.Read,
			4096, FileOptions.WriteThrough);
		DataWriter = new BinaryWriter(_outStream);
	}

	public static void Main(string[] args)
	{
		// OutFile = new FileStream("out.jsonl", FileMode.Append, FileAccess.Write, FileShare.Read);

		var cert = X509Certificate2.CreateFromPemFile(Path.Combine(args[1], "fullchain.pem"), Path.Combine(args[1], "privkey.pem"));

		var wss = new WebSocketServer(IPAddress.Parse(args[0]), 7777, true)
		{
			KeepClean = false,
			SslConfiguration =
			{
				EnabledSslProtocols = SslProtocols.Tls12,
				ServerCertificate = new X509Certificate2(cert.Export(X509ContentType.Pkcs12))
			}
		};

		if (args[2] == "log")
			wss.AddWebSocketService<DatapadLogger>("/");
		else if (args[2] == "emulate")
			wss.AddWebSocketService<DatapadWsInterop>("/");

		wss.Start();
		Lumberjack.Logger.Info("Websocket started");

		ExitHandle = new ManualResetEventSlim();
		ExitHandle.Wait();

		// OutFile.Close();
	}
}