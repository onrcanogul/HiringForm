using HiringForm.Contexts;
using HiringForm.Repositories;
using HiringForm.Services;
using Microsoft.EntityFrameworkCore;

namespace HiringForm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IApplicantService, ApplicantService>();
            builder.Services.AddScoped<IApplicantRepository, ApplicantRepository>();

            builder.Services.AddDbContext<HiringFormContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("Db")));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddNewtonsoftJson();

            var app = builder.Build();

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

            app.UseCors("AllowAll");

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
