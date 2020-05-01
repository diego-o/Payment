using Payment.Infrastructure.Entities;
using System;

namespace Payment.Infrastructure.CustomAttributes
{
    public class ServiceGatewayAttribute : Attribute
    {
        public TipoPagamento TipoPagamento { get; set; }
    }
}
