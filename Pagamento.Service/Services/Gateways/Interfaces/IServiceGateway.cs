using Payment.Infrastructure.Entities;

namespace Payment.Service.Services.Gateways.Interfaces
{
    public interface IServiceGateway
    {
        Pagamento EnviarPagamento(Pagamento pagamento);
        Pagamento ConsultarRetornoPagamento(Pagamento pagamento);
    }
}
