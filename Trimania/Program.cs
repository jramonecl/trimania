using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using TriMania.Domain.Shopping;
using TriMania.Infra.Database.Context;

namespace Trimania
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            Initializer(host);
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }

        private static void Initializer(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                db.Database.EnsureCreated();

                if (!db.Product.Any())
                {
                    db.Product.Add(Product.CreateNew("Curso do balta.io", 99.99M));
                    db.Product.Add(Product.CreateNew("Curso do desenvolvedor.io", 120));
                    db.Product.Add(Product.CreateNew("Curso da pluralsight.com", 250));

                    db.SaveChanges();
                }
            }
        }
    }
}