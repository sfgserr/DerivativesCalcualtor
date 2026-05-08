using DerivativesCalculator.Differentiation.ExpressionNodes;
using DerivativesCalculator.Differentiation.Extensions;

namespace DerivativesCalculator.Differentiation.BinaryOperations;

public class Subtraction : IBinaryOperation
{
    public string Operator => "-";

    public bool IsCommutative => false;

    public string DifferentiateRule => "d/dx(u-v) = u' - v'";

    public ExpressionNode Differentiate(
        ExpressionNode a, ExpressionNode b,
        ExpressionNode aDiff, ExpressionNode bDiff)
    {
        return Evaluate(aDiff, bDiff);
    }

    public ExpressionNode Evaluate(ExpressionNode a, ExpressionNode b)
    {
        if (a.Type == ExpressionType.Constant && b.Type == ExpressionType.Constant)
            return new ConstantNode(a.GetValue() - b.GetValue());

        if (a.Type == ExpressionType.Constant && a.GetValue() == 0)
            return new ConstantNode(-1) * b;

        if (b.Type == ExpressionType.Constant && b.GetValue() == 0)
            return a;

        return new BinaryOperationNode(this, a, b);
    }
}
