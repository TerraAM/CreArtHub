using Adapter;
using CreArtHub.Adapter.Repository;
using CreArtHub.Adapter.Transaction;
using CreArtHub.App.Data;
using CreArtHub.App.Interactors;
using CreArtHub.App.Mappers;
using CreArtHub.Domain.Entity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreArtHub
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
			services.AddRazorPages();
			services.AddControllersWithViews();

			//services.AddDistributedMemoryCache();
			//services.AddSession(options =>
			//{
			//	options.Cookie.Name = "MySessionCookie";
			//	options.IdleTimeout = TimeSpan.FromMinutes(30);
			//	options.Cookie.IsEssential = true;
			//});

			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(options =>
				{
					options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
					options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
				});

			services.AddDbContext<WebDBContext>(
				options => options.UseSqlite(Configuration.GetConnectionString("MyConnection"))
			);

			services.AddTransient<IUnitWork, UnitWork>();

			services.AddScoped<BoughtProductInteractor>();
			services.AddScoped<CommentInteractor>();
			services.AddScoped<FileInteractor>();
			services.AddScoped<LikeInteractor>();
			services.AddScoped<PostInteractor>();
			services.AddScoped<ProductInteractor>();
			services.AddScoped<SubscriberInteractor>();
			services.AddScoped<SubscriptionInteractor>();
			services.AddScoped<RoleInteractor>();
			services.AddScoped<UserInteractor>();
			services.AddScoped<FeedBackInteractor>();
			services.AddScoped<CategoryInteractor>();

			services.AddScoped<IRepository<BoughtProduct>, BoughtProductRepository>();
			services.AddScoped<IRepository<Comment>, CommentRepository>();
			services.AddScoped<IRepository<File>, FileRepository>();
			services.AddScoped<IRepository<Like>, LikeRepository>();
			services.AddScoped<IRepository<Post>, PostRepository>();
			services.AddScoped<IRepository<Product>, ProductRepository>();
			services.AddScoped<IRepository<Subscriber>, SubscriberRepository>();
			services.AddScoped<IRepository<Subscription>, SubscriptionRepository>();
			services.AddScoped<IRepository<Role>, RoleRepository>();
			services.AddScoped<IRepository<User>, UserRepository>();
            services.AddScoped<IRepository<FeedBack>, FeedBackRepository>();
            services.AddScoped<IRepository<Category>, CategoryRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			//app.UseSession();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
			});
		}
    }
}
