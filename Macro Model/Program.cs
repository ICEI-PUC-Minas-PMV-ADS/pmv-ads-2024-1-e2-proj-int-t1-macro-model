using Macro_Model.Interfaces;
using Macro_Model.Models;
using Macro_Model.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace Macro_Model
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

			builder.Services.AddDbContext<AppDbContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

<<<<<<< HEAD
			builder.Services.Configure<CookiePolicyOptions>(options =>
			{
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			}
			);
=======
            builder.Services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            }
            );

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.AccessDeniedPath = "/Cadastro/AccessDenied/";
                    options.LoginPath = "/Login/Login/";

				});



            builder.Services.AddScoped<ICadastroRepository, CadastroRepository>();
>>>>>>> 5cbf18c9b84570393ab4a5d15b52e40679f3d6a4

			builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(options =>
				{
					options.AccessDeniedPath = "/Cadastro/AccessDenied/";
					options.LoginPath = "/Login/Login/";

				});


<<<<<<< HEAD

			builder.Services.AddScoped<ICadastroRepository, CadastroRepository>();

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
			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllerRoute(

				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");
=======
            app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();
>>>>>>> 5cbf18c9b84570393ab4a5d15b52e40679f3d6a4


			app.Run();
		}
	}
}
