namespace Payment.Infrastructure.DatabaseSettings
{
    public interface IPagamentoDataBaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}