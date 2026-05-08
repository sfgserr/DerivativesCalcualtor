using DerivativesCalculator.Core.Contracts;
using DerivativesCalculator.Differentiation.Services;
using DerivativesCalculator.Differentiation.SimplificationPatterns;
using DerivativesCalculator.Differentiation.ExpressionNodeVisitors;
using Microsoft.Extensions.DependencyInjection;

namespace DerivativesCalculator.Differentiation.Configuration;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddDifferentiateService(this IServiceCollection services)
    {
        services.AddScoped<IDifferentiateService, DifferentiateService>()
            .AddScoped<SimplificationPattern, PutRightNodeInNumeratorSimplificationPattern>()
            .AddScoped<SimplificationPattern, PutLeftNodeInNumeratorSimplificationPattern>()
            .AddScoped<SimplificationPattern, BothNodesAreRatiosSimplificationPattern>()
            .AddScoped<SimplificationPattern, DivisionFactorSimplificationPattern>()
            .AddScoped<SimplificationPattern, MultiplicationFactorSimplificationPattern>()
            .AddScoped<SimplificationVisitor>()
            .AddScoped<DifferentiateVisitor>()
            .AddScoped<ExtractFactorsVisitor>();

        return services;
    }
}
