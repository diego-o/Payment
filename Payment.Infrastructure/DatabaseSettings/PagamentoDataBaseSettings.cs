
namespace Payment.Infrastructure.DatabaseSettings
{
    public class PagamentoDataBaseSettings : IPagamentoDataBaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
