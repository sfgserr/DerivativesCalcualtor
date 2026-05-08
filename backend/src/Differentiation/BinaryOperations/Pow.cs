using DerivativesCalculator.Differentiation.ExpressionNodes;
using DerivativesCalculator.Differentiation.Extensions;
using DerivativesCalculator.Differentiation.Utils; 

namespace DerivativesCalculator.Differentiation.BinaryOperations;

public class Pow : IBinaryOperation
{
    public string Operator => "^";

    public bool IsCommutative => false;

    public string DifferentiateRule => "d/dx(u^v) = u^v * (v' * ln(u) + v * u' / u)";

    public ExpressionNode Differentiate(
        ExpressionNode a,
        ExpressionNode b,
        ExpressionNode aDiff,
        ExpressionNode bDiff)
    {
        return (a ^ b) * (bDiff * new FunctionNode("ln", a) + b * (aDiff / a));
    }

    public ExpressionNode Evaluate(ExpressionNode a, ExpressionNode b)
    {
        if (a.Type == ExpressionType.Constant && b.Type == ExpressionType.Constant)
            return new ConstantNode(Math.Pow(a.GetValue(), b.GetValue()));

        if (a.Type == ExpressionType.Constant && a.GetValue() == 0)
            return ConstantNode.Zero;

        if (b.Type == ExpressionType.Constant && b.GetValue() == 0)
            return new ConstantNode(1);

        if (b.Type == ExpressionType.Constant && Math.Abs(b.GetValue() - 1) < MathD.Epsilon)
            return a;

        if (a.Type == ExpressionType.Constant && Math.Abs(a.GetValue() - 1) < MathD.Epsilon)
            return new ConstantNode(1);

        return new BinaryOperationNode(this, a, b);
    }
}
