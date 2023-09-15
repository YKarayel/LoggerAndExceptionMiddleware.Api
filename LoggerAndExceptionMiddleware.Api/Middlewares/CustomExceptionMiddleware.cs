using LoggerAndExceptionMiddleware.Api.ExceptionConfigurations;
using LoggerAndExceptionMiddleware.Api.Model;
using LoggerAndExceptionMiddleware.Api.Service;
using Serilog;

namespace LoggerAndExceptionMiddleware.Api.Middlewares
{
	public class CustomExceptionMiddleware
	{
		private readonly RequestDelegate _next;


		public CustomExceptionMiddleware(RequestDelegate next)
		{
			_next = next;
		
		}

		public async Task Invoke(HttpContext context)
		{
			
			try
			{
				await _next.Invoke(context);
			}catch(Exception e)
			{
				Log.Warning(e.ToString());

			}
		}
	}
}
