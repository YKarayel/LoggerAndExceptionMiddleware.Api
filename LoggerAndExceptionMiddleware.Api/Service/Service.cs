using LoggerAndExceptionMiddleware.Api.ExceptionConfigurations;
using LoggerAndExceptionMiddleware.Api.Model;
using LoggerAndExceptionMiddleware.Api.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Serilog;

namespace LoggerAndExceptionMiddleware.Api.Service
{
	public class Service<T> : IService<T> where T : class
	{
		private readonly AppDbContext _context;

		public Service(AppDbContext context)
		{
			_context = context;
		}

		public async Task<T> GetByIdAsync(int id)
		{
			var hasData = await _context.Set<T>().FindAsync(id);

			if(hasData is null)
			{
				Log.Warning($"404 from GetByIdAsync({id}) request");
				return null;
			}
			return hasData;

		}
	}
}
