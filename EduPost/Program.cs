using EduPost.Data;
using EduPost.Models;
using EduPost.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EduPost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            //builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();
            //builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddIdentity<User, Role>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = true;
            });

            builder.Services.AddControllersWithViews();
            builder.Services.AddSignalR();
            builder.Services.AddScoped<NotificationHub>();
			builder.Services.AddScoped<ReactionService>();
			builder.Services.AddScoped<NotificationViewComponent>();
            builder.Services.AddScoped<AvatarViewComponent>();
            builder.Services.AddScoped<ImageConverter> ();
            builder.Services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConsole();
                loggingBuilder.AddDebug();
            });

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<NotificationHub>("/notificationHub");
                // Other mappings
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=LandingPage}/{action=LandingPage}/{id?}");

            app.Use(async (context, next) =>
            {
                var path = context.Request.Path;
                // Check if the current request path is accessing login or register pages
                var isAccessingAllowedPaths = path.StartsWithSegments("/Identity/Account/Login")
                                              || path.StartsWithSegments("/Identity/Account/Logout")
                                              || path.StartsWithSegments("/Identity/Account/ForgotPassword")
                                              || path.StartsWithSegments("/Identity/Account/RegisterConfirmation")
                                              || path.StartsWithSegments("/LandingPage/LandingPage");


                var isStaticFile = path.StartsWithSegments("/css") || path.StartsWithSegments("/js") || path.StartsWithSegments("/images");

                if (!context.User.Identity.IsAuthenticated && !isAccessingAllowedPaths && !isStaticFile)
                {
                    context.Response.Redirect("/Identity/Account/Login");
                }
                else
                {
                    await next();
                }
            });

            app.MapRazorPages();

            app.Run();
        }
    }
}