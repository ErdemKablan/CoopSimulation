
using CoopSimulation.Services.RabbitServices;
using Microsoft.Extensions.DependencyInjection;

namespace CoopSimulation.Services
{
    public class CoopService
    {
        public static void CoopDependencyInjection(IServiceCollection services)
        {
            services.AddSingleton<RabbitService>();
        }
    }
}
