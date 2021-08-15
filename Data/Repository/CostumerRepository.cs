using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MyCredit.API.Model;


namespace MyCredit.API.Data.Repository
{
    public class CostumerRepository : ICostumerRepository
    {

		private readonly ILoggerFactory _loggerFactory;
		private readonly ILogger<CostumerRepository> _log;
		private readonly IConfiguration _config;

		public CostumerRepository(ILoggerFactory loggerFactory, IConfiguration config)
		{
			_loggerFactory = loggerFactory;
			_log = loggerFactory.CreateLogger<CostumerRepository>();
			_config = config;
		}

		#region LoadModel

		public List<KeyValuePair<int,string>> Load ()
		{
			List<KeyValuePair<int, string>> lista;

			try
			{
				lista = new List<KeyValuePair<int, string>>()
				{
					new KeyValuePair<int, string>(1, "João"),
					new KeyValuePair<int, string>(2, "Maria"),
					new KeyValuePair<int, string>(3, "Ana"),
				};



			}
			catch (Exception ex)
			{
				throw ex;
			}

			return lista;
		}


		#endregion


		#region Retrieve Data

		

		public string Get(int id)
		{
			List<KeyValuePair<int, string>> dados;
			string Name;
				dados = Load();
				Name = dados.First(d => d.Key == id).Value;

			return Name;
		}


		#endregion
	}

}

