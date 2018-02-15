using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectDelivery.Infra.Bus;
using ProjectDelivery.Infra.Identity.Model;
using ProjectDelivery.Infra.IoC;
using ProjectDelivery.Services.Api.Configuracoes;

namespace ProjectDelivery.Services.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityWithMongoStoresUsingCustomTypes<Usuario, UsuarioRole>(Configuration.GetSection("MongoConnectionStrings:ConnectionStringFull").Value)
                .AddDefaultTokenProviders();

            services.AddAuthorization(opt => PolicyConfig.Configurar(opt));

            AuthenticationConfig.Configurar(services, Configuration);

            NativeInjection.RegisterDependencys(services);

            services.AddOptions();

            services.AddMvc(opt =>
            {
                var policy = new AuthorizationPolicyBuilder()
               .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
               .RequireAuthenticatedUser()
               .Build();

                opt.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = "Delivery API",
                    Version = "v1"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IHttpContextAccessor accessor)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Delivery API v1");
            });

            app.UseAuthentication();
            app.UseMvc();
         
            InMemoryBus.ContainerAccessor = () => accessor.HttpContext.RequestServices;
        }
    }
}
