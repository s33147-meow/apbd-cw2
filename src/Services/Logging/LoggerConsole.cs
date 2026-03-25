namespace Tmp.Services.Logging;

public class LoggerConsole : ILogger {
	public void Log(LogLevel level, object obj) {
		Console.WriteLine($"[{level switch { LogLevel.TRACE => "TRC", LogLevel.INFO => "INF" }}] {obj}");
	}
}
