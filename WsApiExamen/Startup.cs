using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Net;
using WsApiExamen.Entities;
using WsApiExamen.Models;
using Microsoft.EntityFrameworkCore;
using WsApiExamen.Infrastructure.Abstract;
using WsApiExamen.Infrastructure.Concrete;

namespace WsApiExamen
{
    /// <summary>
    /// Clase de inicio utilizada para configurar los servicios y la propia API
    /// </summary>
    /// <param name="_IConfiguration">Interfaz de configuración</param>
    public class Startup(IConfiguration _IConfiguration)
    {
        /// <summary>
        /// Método utilizado para configurar los servicios API
        /// </summary>
        /// <param name="services">Servicios a configurar</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ExamenDbContext>(options => options.UseSqlServer(_IConfiguration.GetConnectionString("SqlServer")));

            #region Configuración de servidor

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls13;

            services.Configure<KestrelServerOptions>(options =>
            {
                options.AddServerHeader = false;
            });

            #endregion

            #region Configuración de Swagger

            services.AddSwaggerGen(options =>
            {
                SwaggerApiModel swaggerAPI = _IConfiguration.GetSection("Swagger").Get<SwaggerApiModel>() ?? new();
                options.SwaggerDoc(swaggerAPI.Version, new OpenApiInfo
                {
                    Version = swaggerAPI.Version,
                    Title = swaggerAPI.Title,
                    Description = swaggerAPI.Description,
                    TermsOfService = new Uri(uriString: swaggerAPI.TermsOfService),
                    Contact = new OpenApiContact
                    {
                        Name = swaggerAPI.ContactName,
                        Url = new Uri(uriString: swaggerAPI.ContactUrl)
                    }
                });

            });


            #endregion

            #region Injección de dependencias

            services.AddTransient<IExamenRepository, ExamenRepository>();

            #endregion

            #region Configuración del proyecto

            services.AddControllers((options) =>
            {
                options.ModelValidatorProviders.Clear(); //No usar model state ya que se usará mejor FluentValidation
            });

            services.Configure<ApiBehaviorOptions>((options) =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            #endregion


        }

        /// <summary>
        /// Method used to configure API
        /// </summary>
        /// <param name="app">Application builder</param>
        /// <param name="env">Web host environment</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            #region Swagger

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                SwaggerApiModel swaggerAPI = _IConfiguration.GetSection("Swagger").Get<SwaggerApiModel>() ?? new();
                c.RoutePrefix = string.Empty;
                c.DefaultModelExpandDepth(depth: 2);
                c.DefaultModelRendering(modelRendering: ModelRendering.Model);
                c.DefaultModelsExpandDepth(depth: -1);
                c.DisplayOperationId();
                c.DisplayRequestDuration();
                c.SwaggerEndpoint(url: swaggerAPI.EndpointUrl, name: swaggerAPI.EndpointName);
                c.OAuthClientId(value: "swagger-ui");
                c.OAuthUseBasicAuthenticationWithAccessCodeGrant();
            });

            #endregion

            #region Configuraciones extras

            if (!env.IsDevelopment())
                app.UseHsts();

            app.UseForwardedHeaders(options: new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseRouting();
            app.UseAuthentication();

            app.UseEndpoints(options =>
            {
                options.MapControllers();
                options.MapDefaultControllerRoute();
            });

            #endregion
        }

    }
}
