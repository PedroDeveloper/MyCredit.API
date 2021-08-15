using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using MyCredit.API.Data.Repository;
using MyCredit.API.Model;

namespace MyCredit.API.Business
{
	public class CustomersBO : ICustomersBO
	{
		private readonly ILoggerFactory _loggerFactory;
		private readonly ILogger<CustomersBO> _log;
		private readonly IConfiguration _config;

		public CustomersBO(ILoggerFactory loggerFactory, IConfiguration config)
		{
			_loggerFactory = loggerFactory;
			_log = loggerFactory.CreateLogger<CustomersBO>();
			_config = config;

		}


		#region Retrieve Repository

		public string GetCustomer(int id)
        {
			CostumerRepository costumerRepository = new CostumerRepository(_loggerFactory,_config);
			Customer customer = new Customer();
			string Name = costumerRepository.Get(id);

			if (!string.IsNullOrEmpty(Name))
			{
				return Name;
			}
            else
            {
				throw new Exception ("Não foi encontrado um Cliente com esse ID");
            }

		}

		#endregion
	}

	
}
