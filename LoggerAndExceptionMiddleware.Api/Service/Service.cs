using LoggerAndExceptionMiddleware.Api.Model;
using LoggerAndExceptionMiddleware.Api.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Serilog;

namespace LoggerAndExceptionMiddleware.Api.Service
{
	public class Service<T> : IService<T> where T : class
	{
		private readonly AppDbContext _context;
		private readonly DbSet<T> _dbSet;
		public Service(AppDbContext context)
		{
			_context = context;
			_dbSet = _context.Set<T>();
			
		}

		public async Task<T> GetByIdAsync(int id)
		{
			var hasData = await _dbSet.FindAsync(id);
			return hasData;
		}
	}
}
