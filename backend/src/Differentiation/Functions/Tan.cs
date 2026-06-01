using DerivativesCalculator.Differentiation.ExpressionNodes;

namespace DerivativesCalculator.Differentiation.Functions;

public class Tan : IFunction
{
    public string Name => "tan";

    public ExpressionNode Differentiate(ExpressionNode body)
    {
        return new ConstantNode(1) / (new FunctionNode(FunctionRegistry.GetFunction("cos")!, body) ^ new ConstantNode(2));
    }
}
