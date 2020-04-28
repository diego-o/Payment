using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Payment.Infrastructure.Entities
{
    public class Pagamento
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string NomeCliente { get; set; }
        public string Transacao { get; set; }
        public string NumeroConfirmacao { get; set; }
        public decimal ValorTransacao { get; set; }
        public DateTime DataTransacao { get; set; }

        [BsonRepresentation(BsonType.String)]  
        public TipoPagamento TipoPagamento { get; set; }
    }
}
