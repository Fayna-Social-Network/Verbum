using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using Verbum.Application;
using Verbum.Application.Common.Mappings;
using Verbum.Application.Hubs;
using Verbum.Application.Interfaces;
using Verbum.Persistence;
using Verbum.WebApi;
using Verbum.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;



builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IVerbumDbContext).Assembly));
});

builder.Services.AddApplication();
builder.Services.AddPersistans(configuration);
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
); ;

builder.Services.AddCors();

builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:44313";
        options.Audience = "VerbumWepApi";
        options.RequireHttpsMetadata = false;

    });

builder.Services.AddVersionedApiExplorer(options =>
    options.GroupNameFormat = "'v'VVV");
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>,
    ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen();
builder.Services.AddApiVersioning();
builder.Services.AddSignalR();

var app = builder.Build();

app.UseCors(x => x
        .WithOrigins("http://localhost:8080")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed(origin => true)
        .AllowCredentials());

app.UseSwagger();
app.UseSwaggerUI(
//    config =>
//{

//    foreach (var description in provider.ApiVersionDescriptions)
//    {
//        config.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
//            description.GroupName.ToUpperInvariant());

//        config.RoutePrefix = string.Empty;
//    }
//}
);
app.UseCustomExceptionHandler();

app.UseHttpsRedirection();


app.UseApiVersioning();

app.UseRouting();
app.UseAuthorization();
app.UseAuthentication();



app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<VerbumHub>("/verbum/hub");
   
});


using (var scope = app.Services.CreateScope()) {
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<VerbumDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception ex) {
        
    }
}

app.Run();

