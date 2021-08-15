using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyCredit.API.Business;
using MyCredit.API.Model;
using MyCredit.API.Data.Repository;

namespace MyCredit.API.Controllers
{
	[EnableCors("Policy1")]
	[ApiController]
	[Route("api/[controller]")]

	public class CustomersController : ControllerBase
	{
		private readonly ILoggerFactory _loggerFactory;
		private readonly ILogger<CustomersController> _log;
		private readonly IConfiguration _config;

		public CustomersController(ILoggerFactory loggerFactory, IConfiguration config)
		{
			_loggerFactory = loggerFactory;
			_log = loggerFactory.CreateLogger<CustomersController>();
			_config = config;
		}
		/// <summary>
		/// Retorna nome do cliente dado o ID
		/// </summary>
		/// <remarks>
		/// <para>
		///		
		/// </para>
		///	<![CDATA[ A lista é composta por:  </br>
		///	<b><font color=#FF0000>1 - João</font></b> </br>
		///	<b><font color=#FF0000>2 - Maria</font></b> </br>
		///	<b><font color=#FF0000>3 - Ana</font></b> </br>
		/// ]]>
		///	
		/// <para>
		/// </para>
		/// 
		/// </remarks>
		/// <returns>nome do cliente</returns>

		[HttpPost("{id}")]
		[ProducesResponseType(typeof(Customer),StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult Post(int id)
		{
			CustomersBO customersBO;
			ObjectResult response;
			string result;
			try
			{
				_log.LogInformation($"Starting Post)");

				customersBO = new CustomersBO(_loggerFactory, _config);

				result = customersBO.GetCustomer(id);

				response = Ok(result); 

				_log.LogInformation($"Finishing Post");
			}
			catch (Exception ex)
			{
				_log.LogError(ex.Message);
				response = StatusCode(500, ex.Message);
			}

			return response;
		}

	}
}
