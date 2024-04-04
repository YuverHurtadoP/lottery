using lottery.Application.InterfaceLotteryUseCase;
using lottery.Application.LotteryUseCaseImpl;
using lottery.Domain.Repository;
using lottery.Models;
using lottery.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json.Serialization;

namespace lottery.IOC
{
    public static class Dependence
    {

        public static void InjectDependency(this IServiceCollection services, IConfiguration Configuration)
        {


            services.AddDbContext<LotteryContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("conexionBD")));
            services.AddControllers().AddJsonOptions(
                opt => { opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; }
            );

            services.AddScoped<IProductReposity, ProductReposityImpl>();
            services.AddScoped<IGenericRepository<Product>, GenericRepositoryImpl<Product>>();
            services.AddScoped<IGenericRepository<Ticket>, GenericRepositoryImpl<Ticket>>();
            services.AddScoped<ILotteryProductUseCase, LotteryProductUseCaseImpl>(); // Ejemplo de registro de la implementación de ILotteryProductUseCase
            services.AddScoped<ILotteryTicketUseCase, LotteryTicketUseCase>();
    


        }
    }
}
