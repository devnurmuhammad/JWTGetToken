using Microsoft.OpenApi.Models;

namespace JWTGetToken.CustomMiddlewares
{
    public class CustomMiddleware
    {
        private RequestDelegate _requestDelegate;

        public CustomMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }
        public void InvokeAsync(HttpContext context)
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("V1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "AuthDemo",
                    Description = "Auth Demo Description"
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Description = "Bearer Authentication",
                    Type = SecuritySchemeType.Http
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement(){
                {
                    new OpenApiSecurityScheme()
                    {
                        Reference = new OpenApiReference()
                        {
                            Id = "Bearer",
                            Type = ReferenceType.SecurityScheme
                        }
                    },
                        new List<string> ()
                    }
                });
            });
        }
    }
}
