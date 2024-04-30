using MB.Application.Services;
using MB.Contracts.IServices;
using MB.Data.EfCore;
using MB.Data.EfCore.Repositories;
using MB.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MB.Configuration
{
    public class Bootstrapper
    {
        public static void RegisterContext(IServiceCollection services , string connectionString)
        {
            services.AddDbContext<MBContext>(opt => {
                opt.UseSqlServer(connectionString, b => b.MigrationsAssembly("MB.Data.EfCore"));
            });
        }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddTransient<ITransactionService, TransactionService>();
        }
    }
}
