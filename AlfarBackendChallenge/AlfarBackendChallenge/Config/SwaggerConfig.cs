using Microsoft.OpenApi.Models;

namespace AlfarBackendChallenge.Config;

public static class SwaggerConfig
{
    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(config =>
        {
            config.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "AlfarBackendChallenge",
                Description = "This API is part of a series of group challenges and is for educational purposes only.",
                License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT")},
                Contact = new OpenApiContact() { Name = "Emerson Moonlit", Email = "emoonlit@gmail.com", Url = new Uri("https://emoonlit.dev")}
            });
        });

        return services;
    }

    public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        });
    
        return app;
    }
}