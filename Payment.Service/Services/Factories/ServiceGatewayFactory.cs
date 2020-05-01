using System;
using System.Linq;
using System.Reflection;
using Payment.Infrastructure.Entities;
using Payment.Infrastructure.CustomAttributes;
using Payment.Service.Services.Gateways.Interfaces;

namespace Payment.Service.Services.Factories
{
    internal static class ServiceGatewayFactory
    {
        public static IServiceGateway ServiceGateway(TipoPagamento tipoPagamento)
        {
            var definedTypes = Assembly.GetExecutingAssembly().DefinedTypes
                                       .Where(t => t.CustomAttributes.Any(c => c.AttributeType == typeof(ServiceGatewayAttribute)))
                                       .ToList();

            var typeInfoClass = definedTypes.Find(
                t => t.CustomAttributes.Any(c => c.NamedArguments.Any(t => (TipoPagamento)t.TypedValue.Value == tipoPagamento))
            );

            return (IServiceGateway)Activator.CreateInstance(typeInfoClass);
        }
    }
}
