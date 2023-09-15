using LoggerAndExceptionMiddleware.Api.ExceptionConfigurations;
using LoggerAndExceptionMiddleware.Api.Model;
using LoggerAndExceptionMiddleware.Api.Repository;
using LoggerAndExceptionMiddleware.Api.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace LoggerAndExceptionMiddleware.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IService<Products> _service;

		public ProductsController(IService<Products> service)
		{
			_service = service;
		}
	

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			 var response = await _service.GetByIdAsync(id);
			
			return Ok(response);
		}
	}
}
