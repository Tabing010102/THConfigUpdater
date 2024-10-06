using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using THConfigUpdater.Server.Data;
namespace THConfigUpdater.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<THCUSDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("THCUSDbContext") ?? throw new InvalidOperationException("Connection string 'THCUSDbContext' not found.")));

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // apply db migration
            app.Services.GetRequiredService<THCUSDbContext>().Database.Migrate();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
