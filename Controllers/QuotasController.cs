	using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MyCredit.API.Business;
using MyCredit.API.Model;

namespace MyCredit.API.Controllers
{
	[EnableCors("Policy1")]
	[ApiController]
	[Route("api/[controller]")]

	public class QuotasController : ControllerBase
	{
		private readonly ILoggerFactory _loggerFactory;
		private readonly ILogger<QuotasController> _log;
		private readonly IConfiguration _config;

		public QuotasController(ILoggerFactory loggerFactory, IConfiguration config)
		{
			_loggerFactory = loggerFactory;
			_log = loggerFactory.CreateLogger<QuotasController>();
			_config = config;
		}

		/// <summary>
		/// Inserir valor, parcelas e juros
		/// </summary>
		/// <remarks>
		/// <para>
		///		
		/// </para>
		///	<![CDATA[ Exemplo:  </br>
		///	
		/// {
		///		 "value": 150,
		///		 "quota": 10,
		///		 "rate": 5
		 ///}
		 /// ]]>
		 ///	
		 /// 
		 /// </remarks>
		 /// <returns>Valor total a ser pago</returns>


	[HttpPost]
		[ProducesResponseType((typeof(Quota)),StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult Post([FromBody] Quota quota)
		{
			QuotasBO quotasBO;
			ObjectResult response;

			try
			{
				_log.LogInformation($"Starting Post('{JsonConvert.SerializeObject(quota, Formatting.None)}')");

				quotasBO = new QuotasBO(_loggerFactory, _config,quota);

				quota = quotasBO.Insert();

				response = Ok(quota);

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
