using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Transport.Iy.AppStart;
using Transport.Iy.Services;

namespace MyApp
{
    internal class Program
    {
        static void Main()
        {
            
            var builder = new ConfigurationBuilder();

            var host = Host.CreateDefaultBuilder()
             .ConfigureServices((context, services) =>
             {
                 services.AddTransient<ISecheduleService, SecheduleService>();
                 services.AddTransient<IFlightService, FlightService>();
                 services.AddTransient<IOrderService, OrderService>();
                 services.AddTransient<IItinerariesService, ItinerariesService>();
             })
             .Build();

            var svc = ActivatorUtilities.CreateInstance<AppStart>(host.Services);
            svc.Run();
        
        }
             
    }


}