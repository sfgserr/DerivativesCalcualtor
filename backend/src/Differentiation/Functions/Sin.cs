using DerivativesCalculator.Differentiation.ExpressionNodes;

namespace DerivativesCalculator.Differentiation.Functions;

public class Sin : IFunction
{
    public string Name => "sin";

    public ExpressionNode Differentiate(ExpressionNode body)
    {
        return new FunctionNode(FunctionRegistry.GetFunction("cos")!, body);
    }
}
