using DerivativesCalculator.Differentiation.ExpressionNodes;

namespace DerivativesCalculator.Differentiation.SimplificationPatterns;

public abstract class SimplificationPattern
{
    public abstract bool Matches(BinaryOperationNode node);

    public abstract ExpressionNode Apply(BinaryOperationNode node);
}
