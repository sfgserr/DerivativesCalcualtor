using Asp.Versioning;
using DerivativesCalculator.Core.Contracts;
using DerivativesCalculator.Core.UseCases.Differentiate;
using DerivativesCalculator.Differentiation.Configuration;
using DerivativesCalculator.WebApi.Authentication;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiVersioning(options =>
    {
        options.ApiVersionReader = new UrlSegmentApiVersionReader();
    })
    .AddMvc();
builder.Services.AddControllers();
builder.Services.AddDifferentiateService();
builder.Services.AddScoped<DifferentiateUseCase>();
builder.Services.AddScoped<IUserContext, UserContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();
app.Run();
