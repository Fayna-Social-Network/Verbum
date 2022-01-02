using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Verbum.WebApi
{
    public class ConfigureSwaggerOptions :IConfigureOptions<SwaggerGenOptions>
    {
       private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider descriptionProvider) =>
            _provider = descriptionProvider;

        public void Configure(SwaggerGenOptions options) {
            foreach (var description in _provider.ApiVersionDescriptions) {
                var apiVersion = description.ApiVersion.ToString();
                options.SwaggerDoc(description.GroupName,
                    new OpenApiInfo
                    {
                        Version = apiVersion,
                        Title = $"Verbum API {apiVersion}",
                        Description = "This is DESCRIPTION",
                        TermsOfService = new Uri("https://www.mysite.com"),
                        Contact = new OpenApiContact
                        {
                            Name = "Verbum Messager",
                            Email = "tellermcs@gmail.com",
                            Url = new Uri("https://www.mysite.com")
                        },
                        License = new OpenApiLicense
                        {
                            Name = "StrikerCode Soft",
                            Url = new Uri("https://www.mysite.com")
                        }
                    });

                options.AddSecurityDefinition($"AuthToken {apiVersion}",
                    new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.Http,
                        BearerFormat = "JWT",
                        Scheme = "bearer",
                        Name = "Authorizaton",
                        Description = "Authorization token"
                    });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                  {
                    new OpenApiSecurityScheme
                    {

                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = $"AuthToken {apiVersion}"
                        }


                    },
                        new  string[] {}
                    }
                });
                options.CustomOperationIds(apiDescription =>
                    apiDescription.TryGetMethodInfo(out MethodInfo methodInfo) ? methodInfo.Name : null);
            }
        }
    }
}
