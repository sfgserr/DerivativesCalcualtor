using DerivativesCalculator.Differentiation.ExpressionNodes;

namespace DerivativesCalculator.Differentiation.Functions;

public interface IFunction
{
    string Name { get; }

    ExpressionNode Differentiate(ExpressionNode body);
}
