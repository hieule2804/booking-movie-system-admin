using BookingMovieSystem_Admin.Components;
using BookingMovieSystem_Admin.Models;
using BookingMovieSystem_Admin.Repository.Impl;
using BookingMovieSystem_Admin.Repository;
using BookingMovieSystem_Admin.Services.Impl;
using BookingMovieSystem_Admin.Services;
using Microsoft.EntityFrameworkCore;
using BookingMovieSystem_Admin.Hub;

namespace BookingMovieSystem_Admin
{
    public class Program
    {
        public static void Main(string[] args)
       {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContextFactory<G5MovieTicketBookingSystemContext>(options =>
                options.UseSqlServer(connectionString));

            // Đăng ký Repository
            builder.Services.AddScoped<IScreenRepository, ScreenRepository>();
            builder.Services.AddScoped<IScreenSeatRepository, ScreenSeatRepository>();
            builder.Services.AddScoped<ICinemaRepository, CinemaRepository>();
            // Đăng ký Service
            builder.Services.AddScoped<IScreenService, ScreenService>();
            builder.Services.AddScoped<IScreenSeatService, ScreenSeatService>();

            builder.Services.AddQuickGridEntityFrameworkAdapter();

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddSignalR();
            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
    app.UseMigrationsEndPoint();
            }

            app.UseHttpsRedirection();

       
                app.UseStaticFiles();
            app.UseAntiforgery();


            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();
            app.MapHub<ScreenSeatHub>("/screenseatHub");
            app.MapHub<CinemaHub>("/cinemaHub");
            app.MapHub<MovieHub>("/movieHub");
            app.MapHub<ShowTimeHub>("/showTimeHub");
            app.MapHub<UserHub>("/userHub");
            app.MapHub<UserHub>("/seatTypeHub");
            app.Run();
        }
    }
}
