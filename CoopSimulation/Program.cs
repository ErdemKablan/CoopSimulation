using CoopSimulation.Services.RabbitServices;
using CoopSimulation.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            CoopService.ConfigureService(serviceCollection);

            using (var serviceProvider = serviceCollection.BuildServiceProvider())
            {
                serviceProvider.GetRequiredService<RabbitService>().StartCoop();
            }
        }
    }
}
