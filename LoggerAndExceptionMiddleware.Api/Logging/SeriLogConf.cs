using Serilog;

namespace LoggerAndExceptionMiddleware.Api.SeriLogConfigurations
{
	public static class SeriLogConf
	{
		public static void SeriLogConfiguration()
		{
			Log.Logger = new LoggerConfiguration()
				.Enrich.FromLogContext()
				.WriteTo.Console()
				.CreateLogger();

		}
	}
}
