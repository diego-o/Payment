using System;
using Payment.Infrastructure.Entities;
using Payment.Service.Gateways;
using Payment.Service.Services.Gateways;
using Payment.Service.Services.Gateways.Interfaces;

namespace Payment.Service.Services.Factories
{
    internal static class ServiceGatewayFactory
    {
        public static IServiceGateway ServiceGateway(TipoPagamento tipoPagamento)
        {
            return tipoPagamento switch
            {
                TipoPagamento.Pagseguro => new MercadoLivreServiceGateway(),
                TipoPagamento.Mercadopago => new PagseguroServiceGateway(),
                _ => throw new ArgumentException("Gateway não definido para este tipo"),
            };
        }
    }
}
