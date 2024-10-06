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
            // Add controllers
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Apply db migration
            using (var scope = app.Services.CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<THCUSDbContext>().Database.Migrate();
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.MapControllers();

            app.Run();
        }
    }
}
