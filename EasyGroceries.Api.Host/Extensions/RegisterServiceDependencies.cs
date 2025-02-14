using EasyGroceries.Api.Data;
using EasyGroceries.Api.Data.Carts;
using EasyGroceries.Api.Data.Customers;
using EasyGroceries.Api.Data.Orders;
using EasyGroceries.Api.Data.Products;
using EasyGroceries.Api.Services.Carts;
using EasyGroceries.Api.Services.Customers;
using EasyGroceries.Api.Services.Orders;
using EasyGroceries.Api.Services.Products;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace EasyGroceries.Api.Host.Extensions
{
    public static class RegisterServiceDependencies
    {
        public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
        {

            //Global Exception Handling
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddProblemDetails();

            //DB Context
            var CONNECTION_STRING = builder.Configuration.GetConnectionString("EasyDbConnection");
            builder.Services.AddDbContextPool<EasyDBContext>(
                options => options.UseSqlServer(CONNECTION_STRING));

            //Logging - Serilog
            var logger = new LoggerConfiguration()
                            .ReadFrom.Configuration(builder.Configuration)
                            .CreateLogger();
            builder.Logging.AddSerilog(logger);
            builder.Host.UseSerilog((ctx, conf) =>
            {
                conf.ReadFrom.Configuration(ctx.Configuration);
            });

            //Services
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICartRepository, CartRepository>();
            builder.Services.AddScoped<ICartService, CartService>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();

            return builder;
        }
    }
}
