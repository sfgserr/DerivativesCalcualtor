using DerivativesCalculator.Differentiation.ExpressionNodes;
using DerivativesCalculator.Differentiation.Extensions;
using DerivativesCalculator.Differentiation.Utils; 

namespace DerivativesCalculator.Differentiation.BinaryOperations;

public class Multiplication : IBinaryOperation
{
    public string Operator => "*";

    public bool IsCommutative => true;

    public string DifferentiateRule => "d/dx(u*v) = u'v + uv'";

    public ExpressionNode Differentiate(
        ExpressionNode a,
        ExpressionNode b,
        ExpressionNode aDiff,
        ExpressionNode bDiff)
    {
        return aDiff * b + bDiff * a;
    }

    public ExpressionNode Evaluate(ExpressionNode a, ExpressionNode b)
    {
        if (a.Type == ExpressionType.Constant && b.Type == ExpressionType.Constant)
            return new ConstantNode(a.GetValue() * b.GetValue());

        if (a.Type == ExpressionType.Constant && a.GetValue() == 0 ||
            b.Type == ExpressionType.Constant && b.GetValue() == 0)
            return ConstantNode.Zero;

        if (b.Type == ExpressionType.Constant && Math.Abs(b.GetValue() - 1) < MathD.Epsilon)
            return a;

        if (a.Type == ExpressionType.Constant && Math.Abs(a.GetValue() - 1) < MathD.Epsilon)
            return b;

        return new BinaryOperationNode(this, a, b);
    }
}
