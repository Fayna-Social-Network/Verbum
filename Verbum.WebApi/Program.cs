using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using Verbum.Application;
using Verbum.Application.Common.Mappings;
using Verbum.Application.Hubs;
using Verbum.Application.Interfaces;
using Verbum.Application.Verbum.Repositories;
using Verbum.Persistence;
using Verbum.WebApi;
using Verbum.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment env = builder.Environment;


builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IVerbumDbContext).Assembly));
});

builder.Services.AddApplication();
builder.Services.AddVerbumRepositories();
builder.Services.AddPersistans(configuration);
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);


builder.Services.AddCors(options => {
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://localhost:8080")
              .AllowCredentials()
              .AllowAnyHeader()
              .AllowAnyMethod();
    }); 
});

builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:7039";
        options.Audience = "VerbumWebAPI";
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

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "Resources")),
        RequestPath = new PathString("/Resources")
});



        

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

app.UseAuthentication();
app.UseRouting();

app.UseCors();

app.UseAuthorization();





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
        Console.WriteLine(ex);
    }
}



app.Run();

