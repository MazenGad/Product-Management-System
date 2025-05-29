using Microsoft.EntityFrameworkCore;
using Product_Management_System.Data;
using Product_Management_System.Repository.Services.Implementation;
using Product_Management_System.Repository.Services.Interfaces;

namespace Product_Management_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

			// Register the DbContext with dependency injection
            builder.Services.AddDbContext<AppDbContext>(options=>
            options.UseSqlServer(
				builder.Configuration.GetConnectionString("DefaultConnection")));


            builder.Services.AddScoped<IProductRepository, ProductRepository>();
			builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
	            pattern: "{controller=Product}/{action=Create}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
