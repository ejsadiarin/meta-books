namespace ultimate_asp_net_core_web_api_2nd_edition.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin() // can use WithOrigins("https://example.com") --> for production environments
                    .AllowAnyMethod() // can use WithMethods("POST", "GET") --> allow specific methods
                    .AllowAnyHeader()); // can use WIthHeaders("accept", "content-type") --> allow specific headers
        });
    
    // ASP.NET Core applications are by default self-hosted, if we want to host our
    // application on IIS, configure IIS integration
    public static void ConfigureIISIntegration(this IServiceCollection services) =>
        services.Configure<IISOptions>(options =>
        {
            // default options --> if not initializing any properties in this options block
            // options (properties): AutomaticAuthentication, AuthenticationDisplayName, ForwardClientCertificate
        });

}