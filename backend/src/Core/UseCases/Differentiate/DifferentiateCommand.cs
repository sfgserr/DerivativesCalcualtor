using DerivativesCalculator.Core.Interfaces;

namespace DerivativesCalculator.Core.UseCases.Differentiate;

public class DifferentiateCommand : ICommandWithResult<DifferentiateResult>
{
    public DifferentiateCommand(string expression)
    {
        Expression = expression;
    }

    public string Expression { get; }
}
