
using Macro_Model.Models;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp.Web.Caching;
using SixLabors.ImageSharp.Web.DependencyInjection;

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

			builder.Services.AddHttpContextAccessor();

			builder.Services.AddImageSharp(
				options =>
				{
					options.BrowserMaxAge = TimeSpan.FromDays(7);
					options.CacheMaxAge = TimeSpan.FromDays(365);
					options.CacheHashLength = 8;
				}).Configure<PhysicalFileSystemCacheOptions>(options =>
				{
					options.CacheFolder = "Imagem";
				}
				);

			builder.Services.AddDbContext<AppDbContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

		



			builder.Services.Configure<CookiePolicyOptions>(options =>
			{
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			}
			);

			builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(options =>
				{
					options.AccessDeniedPath = "/Cadastro/AcessDenied/";
					options.LoginPath = "/Login/Login/";

				});






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
			app.UseImageSharp();
			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllerRoute(

				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");


			app.Run();
		}

	}
}
