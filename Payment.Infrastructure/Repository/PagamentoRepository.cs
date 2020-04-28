using MongoDB.Driver;
using Payment.Infrastructure.DatabaseSettings;
using Payment.Infrastructure.Entities;
using System.Collections.Generic;

namespace Payment.Infrastructure.Repository
{
    public class PagamentoRepository : BaseRepository<Pagamento>
    {
        public PagamentoRepository(IPagamentoDataBaseSettings settings) : base(settings) { }

        public Pagamento Insert(Pagamento pagamento)
        {
            this.Model.InsertOne(pagamento);
            return pagamento;
        }

        public Pagamento GetById(string id) =>
            this.Model.Find(Pagamento => Pagamento.Id == id).FirstOrDefault();

        public List<Pagamento> GetAll() =>
            this.Model.Find(_ => true).ToList();
    }
}
