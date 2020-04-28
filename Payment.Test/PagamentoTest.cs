using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Payment.Infrastructure.Entities;
using Payment.Service.Services.Persistence;
using System.Linq;

namespace Payment.Test
{
    public class PagamentoTest : BaseTest
    {
        [Test]
        public void RealizarPagamentoPagseguro()
        {
            var pagamento = new Pagamento()
            {
                NomeCliente = "Diego",
                TipoPagamento = TipoPagamento.Pagseguro,
                ValorTransacao = 1000
            };

            var pagamentoService = new PagamentoService(this.PagamentoDataBase);
            pagamento = pagamentoService.Inserir(pagamento);

            Assert.IsTrue(!string.IsNullOrEmpty(pagamento.Id));
            Assert.IsTrue(!string.IsNullOrEmpty(pagamento.Transacao));
        }

        [Test]
        public void RealizarPagamentoMercadopago()
        {
            var pagamento = new Pagamento()
            {
                NomeCliente = "Diego",
                TipoPagamento = TipoPagamento.Mercadopago,
                ValorTransacao = 1000
            };

            var pagamentoService = new PagamentoService(this.PagamentoDataBase);
            pagamento = pagamentoService.Inserir(pagamento);

            Assert.IsTrue(!string.IsNullOrEmpty(pagamento.Id));
            Assert.IsTrue(!string.IsNullOrEmpty(pagamento.Transacao));
        }

        [Test]
        public void VerificarPagamento()
        {
            var pagamentoService = new PagamentoService(this.PagamentoDataBase);

            var pagamento = pagamentoService.Listar().Last();
            pagamento = pagamentoService.Verificar(pagamento.Id);

            Assert.IsTrue(!string.IsNullOrEmpty(pagamento.NumeroConfirmacao));
        }
    }
}