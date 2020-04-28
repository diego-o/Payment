using System;
using System.Collections.Generic;
using Payment.Infrastructure.Entities;
using Payment.Infrastructure.Repository;
using Payment.Service.Services.Factories;
using Payment.Infrastructure.DatabaseSettings;

namespace Payment.Service.Services.Persistence
{
    public class PagamentoService
    {
        private readonly PagamentoRepository _pagamentoRepository;

        public PagamentoService(IPagamentoDataBaseSettings pagamentoDataBaseSettings) =>
            _pagamentoRepository = new PagamentoRepository(pagamentoDataBaseSettings);

        public Pagamento Inserir(Pagamento pagamento)
        {
            var serviceGateway = ServiceGatewayFactory.ServiceGateway(pagamento.TipoPagamento);

            pagamento.DataTransacao = DateTime.Now;
            pagamento = serviceGateway.EnviarPagamento(pagamento);
            pagamento = _pagamentoRepository.Insert(pagamento);            
            return pagamento;
        }

        public Pagamento Verificar(string id)
        {
            var pagamento = _pagamentoRepository.GetById(id);
            var serviceGateway = ServiceGatewayFactory.ServiceGateway(pagamento.TipoPagamento);

            pagamento = serviceGateway.ConsultarRetornoPagamento(pagamento);
            return pagamento;
        }

        public List<Pagamento> Listar() =>
            this._pagamentoRepository.GetAll();
    }
}
