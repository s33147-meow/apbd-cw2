namespace Tmp.Services.Logging;

public interface ILogger {
	public void Log(LogLevel level, object obj);
	public void LogTrace(object obj) => Log(LogLevel.TRACE, obj);
	public void LogInfo(object obj) => Log(LogLevel.INFO, obj);
}
