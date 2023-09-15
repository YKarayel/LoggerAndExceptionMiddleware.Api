namespace LoggerAndExceptionMiddleware.Api.Service
{
	public interface IService<T> where T : class
	{
		Task<T> GetByIdAsync(int id);
	}
}
