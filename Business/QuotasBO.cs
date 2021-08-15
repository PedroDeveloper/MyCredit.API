using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using MyCredit.API.Data.Repository;
using MyCredit.API.Model;

namespace MyCredit.API.Business
{
	public class QuotasBO : IQuota
	{
		private readonly ILoggerFactory _loggerFactory;
		private readonly ILogger<QuotasBO> _log;
		private readonly IConfiguration _config;
		Quota _quota;

		public QuotasBO(ILoggerFactory loggerFactory, IConfiguration config,Quota quota)
		{
			_loggerFactory = loggerFactory;
			_log = loggerFactory.CreateLogger<QuotasBO>();
			_config = config;
			 _quota= quota;
		}

		#region Change Data

		public Quota Insert()
		{
			decimal? semJuros;
			try
			{
				semJuros = (_quota.Value * _quota.quota);
				_quota.Rate = (_quota.Rate / 100 * semJuros);
				_quota.Total = semJuros + _quota.Rate;

			}
			catch (Exception ex)
			{
				throw ex;
			}

			return _quota;
		}


		#endregion

	}

	
}
