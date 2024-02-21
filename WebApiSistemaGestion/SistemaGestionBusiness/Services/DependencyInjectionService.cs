using SistemaGestionData.dataBase;
using Microsoft.Extensions.DependencyInjection;
using SistemaGestionData.ContextFactory;
using SistemaGestionData.Interfaces;
using SistemaGestionData.Repositories;
using Microsoft.EntityFrameworkCore;
using SistemaGestionMapper;

namespace SistemaGestionBusiness.Services
{
    public static class DependencyInjectionService
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Registra aquí todos tus servicios
            services.AddScoped <CoderContext>();
            services.AddScoped<IDatabaseContextFactory, DatabaseContextFactory>();
            services.AddScoped<UserMapper>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<UserService>();
            services.AddScoped<IProductoRepository, ProductRepository>();
            services.AddScoped<ProductService>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<SaleService>();
            services.AddScoped<IProductsSoldRepository, ProductsSoldRepository>();
            services.AddScoped<ProductsSoldService>();
            // Agrega más servicios según sea necesario
        }
    }
}
