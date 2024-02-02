
using Microsoft.EntityFrameworkCore;
using Webshop.Business;
using Webshop.Desktop.Core.Interfaces.Business;
using Webshop.Desktop.Core.Interfaces.Repository;
using Webshop.Desktop.Core.Models.Domain;
using Webshop.Repository;
using Webshop.Repositrory.Repository;

namespace Webshop.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<WebshopContext>(options =>
            {
                options.UseMySQL("server=localhost;uid=root;pwd=;database=webshop");
            });

        // Add services to the container
        //Repositories
        builder.Services.AddTransient<IRepository<Product>, Repository<Product>>();
        builder.Services.AddTransient<IRepository<Stock>, Repository<Stock>>();
        builder.Services.AddTransient<IRepository<ShoppingCartItem>, Repository<ShoppingCartItem>>();
        builder.Services.AddTransient<IRepository<OrderItem>, Repository<OrderItem>>();
        builder.Services.AddTransient<IRepository<Size>, Repository<Size>>();  
        builder.Services.AddTransient<IRepository<Like>, Repository<Like>>();
        builder.Services.AddTransient<IProductService, ProductService>();



        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
