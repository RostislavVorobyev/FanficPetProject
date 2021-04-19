using FictionDataLayer;
using FictionDataLayer.Entity;
using FictionDataLayer.Implementations;
using FictionDataLayer.Interfaces;
using FictionLogicLayer;
using FictionLogicLayer.ServiceInterfaces;
using FictionLogicLayer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FictionUILayer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)  
        {
            services.AddDbContext<SQLServerDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<Author, IdentityRole>(opts => {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 1;   
                opts.Password.RequireNonAlphanumeric = false;   
                opts.Password.RequireLowercase = false; 
                opts.Password.RequireUppercase = false; 
                opts.Password.RequireDigit = false; 
            }).AddEntityFrameworkStores<SQLServerDbContext>();
            
            services.AddControllersWithViews();
            services.AddTransient<RepositoryAbstractFabric, EFRepositoryAbstractFabric>();
            services.AddTransient<IFanficService, FanficService>();
            services.AddTransient<IChapterService, ChapterService>();
            services.AddTransient<ITagService, TagService>();
            services.AddTransient<IGenreService, GenreService>();
            services.AddTransient<IRatingService, RatingService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICommentaryService, CommentaryService>();
            services.AddTransient<ILikeService, LikeService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();    
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
