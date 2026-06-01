using DerivativesCalculator.Differentiation.ExpressionNodes;

namespace DerivativesCalculator.Differentiation.Functions;

public class Exp : IFunction
{
    public string Name => "exp";

    public ExpressionNode Differentiate(ExpressionNode body)
    {
        return new FunctionNode(this, body);
    }
}
