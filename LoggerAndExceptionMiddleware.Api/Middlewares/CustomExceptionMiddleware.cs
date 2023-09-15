using LoggerAndExceptionMiddleware.Api.Exceptions;
using LoggerAndExceptionMiddleware.Api.Model;
using LoggerAndExceptionMiddleware.Api.Service;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Text.Json;
using System.Text.Json.Serialization;

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



			}
			catch (ArgumentNullException ex)
			{
				Log.Information(ex.ToString());

				context.Response.StatusCode = 400;
				context.Response.ContentType = "application/json";
				await context.Response.WriteAsync("Argument Null");

			}
			catch (UnauthorizedAccessException ex)
			{
				Log.Information(ex.ToString());

				context.Response.StatusCode = 401;
				context.Response.ContentType = "application/json";
				await context.Response.WriteAsync("Unauthorized Access");
			}
			catch (NotFoundException ex)
			{
				Log.Information(ex.ToString());
				
				context.Response.StatusCode = 404;
				context.Response.ContentType = "application/json";
				var message = "Not Found";

				
				await context.Response.WriteAsync(JsonSerializer.Serialize(message));
			}

			catch (Exception ex)
			{
				Log.Warning(ex.ToString());

				context.Response.StatusCode = 500;
				context.Response.ContentType = "application/json";
				await context.Response.WriteAsync("Something went wrong");

			}
		}
	}
}
