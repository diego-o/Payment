using System;
using Payment.Infrastructure.Entities;
using Payment.Service.Services.Gateways.Interfaces;

namespace Payment.Service.Services.Gateways
{
    internal class PagseguroServiceGateway : IServiceGateway
    {
        public Pagamento ConsultarRetornoPagamento(Pagamento pagamento)
        {
            //consulta na api externa

            pagamento.NumeroConfirmacao = Guid.NewGuid().ToString().Substring(0, 6).ToUpper();
            return pagamento;
        }

        public Pagamento EnviarPagamento(Pagamento pagamento)
        {
            //aplica regras de negócio referente ao gateway específico
            //envia apra api externa

            pagamento.Transacao = Guid.NewGuid().ToString().Substring(0, 6).ToUpper();
            return pagamento;
        }
    }
}
