using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using LazZiya.ExpressLocalization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using onlineShopSolution.ApiIntegration;
using onlineShopSolution.ViewModel.SendMail;
using onlineShopSolution.ViewModel.System.Users;
using onlineShopSolution.WebApp.LocalizationResources;
using onlineShopSolution.WebApp.Models;

namespace onlineShopSolution.WebApp
{
    // cài đặt middleware, request pipeline
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
            services.AddHttpClient();

            var cultures = new[]
            {
                new CultureInfo("en"),
                new CultureInfo("vi"),
            };
            services.AddControllersWithViews()
               .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>())
               .AddExpressLocalization<ExpressLocalizationResource, ViewLocalizationResource>(ops =>
               {
                   // When using all the culture providers, the localization process will
                   // check all available culture providers in order to detect the request culture.
                   // If the request culture is found it will stop checking and do localization accordingly.
                   // If the request culture is not found it will check the next provider by order.
                   // If no culture is detected the default culture will be used.

                   // Checking order for request culture:
                   // 1) RouteSegmentCultureProvider
                   //      e.g. http://localhost:1234/tr
                   // 2) QueryStringCultureProvider
                   //      e.g. http://localhost:1234/?culture=tr
                   // 3) CookieCultureProvider
                   //      Determines the culture information for a request via the value of a cookie.
                   // 4) AcceptedLanguageHeaderRequestCultureProvider
                   //      Determines the culture information for a request via the value of the Accept-Language header.
                   //      See the browsers language settings

                   // Uncomment and set to true to use only route culture provider
                   ops.UseAllCultureProviders = false;
                   ops.ResourcesPath = "LocalizationResources";
                   ops.RequestLocalizationOptions = o =>
                   {
                       o.SupportedCultures = cultures;
                       o.SupportedUICultures = cultures;
                       o.DefaultRequestCulture = new RequestCulture("vi");
                   };
               });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
             .AddCookie(options =>
             {
                 options.LoginPath = "/Account/Login";
                 options.AccessDeniedPath = "/User/Forbidden/";
             });

            //facebook
        //    services.AddAuthentication(options =>
        //    {
        //        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        //    })
        //.AddCookie(options =>
        //{
        //    options.LoginPath = "/account/facebook-login"; // Must be lowercase
        //})
        //.AddFacebook(options =>
        //{
        //    options.AppId = "309864987298931";
        //    options.AppSecret = "754e86a22fb9b2b70dc58099584dc093";
        //});

            //fb2
          
            //services.AddAuthentication(options=> {
            //    options.DefaultChallengeScheme = FacebookDefaults.AuthenticationScheme;
            //    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //}).AddFacebook(options =>
            //{
            //    options.AppId = "309864987298931";
            //    options.AppSecret = "754e86a22fb9b2b70dc58099584dc093";
            //    //options.AccessDeniedPath = "/account/facebook-login";
            //}).AddCookie(options =>
            //{
            //   options.LoginPath = "vi/account/FacebookLogin"; // Must be lowercase
            //});

            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            });




            services.AddControllersWithViews().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>());
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<ISlideApiClient, SlideApiClient>();
            services.AddTransient<IProductApiClient, ProductApiClient>();
            services.AddTransient<ICategoryApiClient, CategoryApiClient>();
            services.AddTransient<IUserApiClient, UserApiClient>();
            services.AddTransient<IOrderApiClient, OrderApiClient>();
            services.AddTransient<IContactApiClient, ContactApiClient>();

            //services.AddTransient<IValidator<LoginRequest>, LoginRequestValidator>();

            services.AddTransient<ISendMailApiClient, SendMailApiClient>();
            services.AddOptions();                                         // Kích hoạt Options
            var mailsettings = Configuration.GetSection("MailSettings");  // đọc config
            services.Configure<MailSettings>(mailsettings);                // đăng ký để Inject
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();
            app.UseRequestLocalization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "Contact",
                   pattern: "{culture}/contact/contact", new
                   {
                       controller = "Contact",
                       action = "Contact"
                   });

                endpoints.MapControllerRoute(
                   name: "Product Category En",
                   pattern: "{culture}/category/{id}", new
                   {
                       controller = "Product",
                       action = "Category"
                   });

                endpoints.MapControllerRoute(
                  name: "Product Category Vn",
                  pattern: "{culture}/danh-muc/{id}", new
                  {
                      controller = "Product",
                      action = "Category"
                  });

                endpoints.MapControllerRoute(
                    name: "Product Detail En",
                    pattern: "{culture}/product/{id}", new
                    {
                        controller = "Product",
                        action = "Detail"
                    });

                endpoints.MapControllerRoute(
                  name: "Product Detail Vn",
                  pattern: "{culture}/san-pham/{id}", new
                  {
                      controller = "Product",
                      action = "Detail"
                  });

                endpoints.MapControllerRoute(
                     name: "default",
                     pattern: "{culture=vi}/{controller=Home}/{action=Index}/{id?}");

                //endpoints.MapGet("/sendmail", async context => {

                //    // Lấy dịch vụ sendmailservice
                //    var sendmailservice = context.RequestServices.GetService<ISendMailApiClient>();

                //    MailContent content = new MailContent
                //    {
                //        To = "nghiepdo.dev@gmail.com",
                //        Subject = "Đơn đặt hàng mới",
                //        Body = "<p><strong>Đơn đặt hàng mới</strong></p>"
                //    };

                //    await sendmailservice.SendMail(content);
                //    await context.Response.WriteAsync("Send mail");
                //});

            });
        }
    }
}
