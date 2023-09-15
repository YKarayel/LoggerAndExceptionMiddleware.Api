using Serilog;

namespace LoggerAndExceptionMiddleware.Api.ExceptionConfigurations
{
	public class NotFoundException : Exception
	{
		public NotFoundException(string? message) : base(message)
		{
			Log.Warning(message);
		}
	}
}
