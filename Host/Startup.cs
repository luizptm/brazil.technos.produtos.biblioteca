using AppService;
using Controller;
using Data;
using Data.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.Owin;
using Security;
using System;
using System.IO;
using System.Reflection;

[assembly: OwinStartup(typeof(Host.Startup))]
namespace Host
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// ConfigureServices
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Produto",
                    Version = "v1",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Luiz Paulo",
                        Email = string.Empty,
                        Url = new Uri("https://github.com/luizptm")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });
                c.DocInclusionPredicate((docName, description) => true);

                //Note: This is just for showing Authorize button on the UI. 
                //Authorize button's behaviour is handled in wwwroot/swagger/ui/index.html
                //c.AddSecurityDefinition("Bearer", new SecurityScheme());

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("InMemoryDatabase"));
            //services.AddDbContext < ApplicationDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("GrupoTechnos")));
            services.AddScoped<ProdutoDbContext, ProdutoDbContext>();
            services.AddScoped<TipoProdutoDbContext, TipoProdutoDbContext>();

            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<ITipoProdutoRepository, TipoProdutoRepository>();

            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IProdutoController, ProdutoController>();

            services.AddSingleton<ITokenAppService, TokenAppService>();
            services.AddSingleton<IApplicationManager, ApplicationManager>();

            //ativando a geração dos tokens de acesso
            TokenConfigurer.Configure(services, this.Configuration);

            #region Authentication
            services.AddAuthentication(o => {
                o.DefaultScheme = SchemesNamesConst.TokenAuthenticationDefaultScheme;
            })
            .AddScheme<TokenAuthenticationOptions, TokenAuthenticationHandler>(SchemesNamesConst.TokenAuthenticationDefaultScheme, o => { });
            #endregion

            // Ativa o uso do token
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });
        }

        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Host");
                c.RoutePrefix = string.Empty;
                c.DocumentTitle = "Produto API V1";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // ativando cors
            app.UseCors(builder => builder.AllowAnyMethod()
                .AllowAnyOrigin()
                .AllowAnyHeader());
        }
    }
}
