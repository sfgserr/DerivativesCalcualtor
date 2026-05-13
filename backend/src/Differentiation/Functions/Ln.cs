using DerivativesCalculator.Differentiation.ExpressionNodes;

namespace DerivativesCalculator.Differentiation.Functions;

public class Ln : IFunction
{
    public string Name => "ln";

    public ExpressionNode Differentiate(ExpressionNode body)
    {
        return new ConstantNode(1) / body;
    }
}
