using Azure.Core;
using LoggerAndExceptionMiddleware.Api.Exceptions;
using LoggerAndExceptionMiddleware.Api.Model;
using LoggerAndExceptionMiddleware.Api.Service;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Runtime.InteropServices;

namespace LoggerAndExceptionMiddleware.Api.Filters
{
	public class NotFoundFilter<T> : IAsyncActionFilter where T : Products
	{
		private readonly IService<T> _service;

		public NotFoundFilter(IService<T> service)
		{
			_service = service;
		}

		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			var idValue = context.ActionArguments.Values.FirstOrDefault();

			if (idValue == null) 
			{
				
				await next.Invoke();
				return;
			}

			var id = (int)idValue;
			var anyEntity = await _service.GetByIdAsync(id);

			if (anyEntity != null)
			{
				await next.Invoke();
				return;
			}

			throw new NotFoundException();
		}
	}
}
