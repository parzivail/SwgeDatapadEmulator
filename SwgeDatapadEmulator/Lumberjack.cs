using NLog;
using NLog.Config;
using NLog.Layouts;
using NLog.Targets;

namespace SwgeDatapadEmulator;

public class Lumberjack
{
	public static readonly Logger Logger;

	static Lumberjack()
	{
		var config = new LoggingConfiguration();

		const string format = "[${longdate}] [${level:uppercase=true}] [${logger}] ${message}";
		var layout = new SimpleLayout(format);

		var logconsole = new ConsoleTarget("consoletarget") { Layout = layout };
		config.AddRule(LogLevel.Debug, LogLevel.Fatal, logconsole);

		LogManager.Configuration = config;

		Logger = LogManager.GetLogger("SwgeDatapadEmu");
	}
}