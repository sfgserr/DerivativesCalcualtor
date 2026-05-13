using DerivativesCalculator.Differentiation.ExpressionNodes;

namespace DerivativesCalculator.Differentiation.Functions;

public class Cos : IFunction
{
    public string Name => "cos";

    public ExpressionNode Differentiate(ExpressionNode body)
    {
        return new ConstantNode(-1) * new FunctionNode(FunctionRegistry.GetFunction("sin")!, body);
    }
}
