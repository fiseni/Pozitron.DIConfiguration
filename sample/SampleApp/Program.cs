using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PozitronDev.DIConfiguration;
using SampleLibrary;
using System;

namespace SampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder()
                    .ConfigureServices((context, services) =>
                    {
                        services.AddBindings(context.Configuration);
                    })
                    .Build();


            using (var scope = host.Services.CreateScope())
            {
                var simpleService = scope.ServiceProvider.GetRequiredService<ISimpleService>();
                Console.WriteLine(simpleService.GetMessage());

                var genericService = scope.ServiceProvider.GetRequiredService<IGenericService<Object>>();
                Console.WriteLine(genericService.GetMessage());
            }
        }
    }
}
