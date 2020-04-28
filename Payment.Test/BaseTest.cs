using NUnit.Framework;
using Payment.Infrastructure.DatabaseSettings;
using Microsoft.Extensions.Configuration;

namespace Payment.Test
{
    public class BaseTest
    {
        protected IPagamentoDataBaseSettings PagamentoDataBase { get; private set; }

        private IConfigurationRoot _configuration;

        [SetUp]
        public void Setup()
        {
            this._configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            this.ConfigureDataBase();
        }

        private void ConfigureDataBase()
        {
            this.PagamentoDataBase = new PagamentoDataBaseSettings()
            {
                ConnectionString = _configuration["ConnectionString"],
                DatabaseName = _configuration["DatabaseName"]
            };
        }
    }
}
