using Bogus;
using Dierentuin_eindopdracht.Models;
using Dierentuin_eindopdracht.Services;
using Microsoft.EntityFrameworkCore;

namespace Dierentuin_eindopdracht
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ZooDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ZooDBconnection"))
            );

            //Scoped because the services have to track changes from the database, if it were singleton it would share the same unedited db leading to stale requests.
            builder.Services.AddScoped<EnclosureService>(); 

            builder.Services.AddScoped<AnimalService>();

            builder.Services.AddScoped<AnimalCategoryService>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider
                    .GetRequiredService<ZooDbContext>();
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
             
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
