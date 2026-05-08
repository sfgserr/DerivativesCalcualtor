using DerivativesCalculator.Core.Contracts;

namespace DerivativesCalculator.Core.UseCases.Differentiate;

public class DifferentiateResult
{
    public DifferentiateResult(string derivative, IReadOnlyCollection<StepRecord> steps)
    {
        Derivative = derivative;
        Steps = steps;
    }

    public DifferentiateResult(string derivative)
    {
        Derivative = derivative;
        Steps = [];
    }

    public string Derivative { get; }

    public IReadOnlyCollection<StepRecord> Steps { get; }
}
