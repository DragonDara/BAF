using BAF.UseCases.ApplicationServices;
using Binance.Net;
using Binance.Net.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BAF.UseCases
{
    public static class DependecyInjection
    {
        public static void AddUseCases(this IServiceCollection service)
        {
            service.AddMediatR(Assembly.GetExecutingAssembly());
            service.AddTransient<IBinanceClient, BinanceClient>();
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
            service.AddScoped<HashBuilder>();
        }
    }
}
