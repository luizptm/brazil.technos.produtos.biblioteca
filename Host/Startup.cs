using AppService;
using Controller;
using Data;
using Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.Owin;
using Owin;
using Security;
using System;
using System.IO;

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
        /// Startup
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
                c.SwaggerDoc("v1", 
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "Produto",
                        Version = "v1",
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                    }
                );

                string caminhoAplicacao = PlatformServices.Default.Application.ApplicationBasePath;
                string nomeAplicacao = PlatformServices.Default.Application.ApplicationName;
                string caminhoXmlDoc = Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");
                c.IncludeXmlComments(caminhoXmlDoc);
            });

            services.AddScoped<ProdutoDbContext, ProdutoDbContext>();
            services.AddScoped<TipoProdutoDbContext, TipoProdutoDbContext>();

            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<ITipoProdutoRepository, TipoProdutoRepository>();

            services.AddSingleton<IProdutoAppService, ProdutoAppService>();
            services.AddSingleton<IProdutoController, ProdutoController>();
            services.AddSingleton<ITokenAppService, TokenAppService>();
            services.AddSingleton<IApplicationManager, ApplicationManager>();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // ativando cors
            app.UseCors();

            //ativando a geração dos tokens de acesso
            //AtivarGeracaoTokenAcesso(appBuilder);
        }

        /// <summary>
        /// AtivarGeracaoTokenAcesso
        /// </summary>
        /// <param name="app"></param>
        private void AtivarGeracaoTokenAcesso(Owin.IAppBuilder app)
        {
            var opcoesConfiguracaoToken = new Microsoft.Owin.Security.OAuth.OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new Microsoft.Owin.PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(1)
            };
            opcoesConfiguracaoToken.Provider = new ProviderDeTokensDeAcesso();

            app.UseOAuthAuthorizationServer(opcoesConfiguracaoToken);
            app.UseOAuthBearerAuthentication(new Microsoft.Owin.Security.OAuth.OAuthBearerAuthenticationOptions());
        }
    }
}
