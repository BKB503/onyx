using Microsoft.OpenApi.Models;
using ONYX.Api.Repository;
using ONYX.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("X-Api-Key", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "X-Api-Key",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "ApiKeyScheme",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Authorization by x-api-key inside request's header, Value is 859B5417-C7EA-4A9C-9346-9AC5BF6A5086",
        //Reference = new OpenApiReference
        //{
        //    Type = ReferenceType.Header,
        //    Id= "X-Api-Key"
        //}
    });
    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
                new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Reference = new Microsoft.OpenApi.Models.OpenApiReference
                    {
                        Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                        Id = "X-Api-Key"
                    }
                },
                new string[] {}
        }
    });
});
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.MapType<Exception>(() => new OpenApiSchema { Type = "object" });
//});
builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI( c=>
    {
       
    });
}

app.MapHealthChecks("/health");

app.UseAuthorization();

app.MapControllers();

app.Run();
