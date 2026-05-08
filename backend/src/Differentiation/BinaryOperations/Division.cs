using DerivativesCalculator.Differentiation.ExpressionNodes;
using DerivativesCalculator.Differentiation.Extensions;
using DerivativesCalculator.Differentiation.Utils; 

namespace DerivativesCalculator.Differentiation.BinaryOperations;

public class Division : IBinaryOperation
{
    public string Operator => "/";

    public bool IsCommutative => false;

    public string DifferentiateRule => "d/dx(u/v) = (u'v - uv') / v^2";

    public ExpressionNode Differentiate(ExpressionNode a, ExpressionNode b, ExpressionNode aDiff, ExpressionNode bDiff)
    {
        return (aDiff * b - bDiff * a) / (b ^ new ConstantNode(2));
    }

    public ExpressionNode Evaluate(ExpressionNode a, ExpressionNode b)
    {
        if (a.Type == ExpressionType.Constant && b.Type == ExpressionType.Constant)
            return new ConstantNode(a.GetValue() / b.GetValue());
        if (a.Type == ExpressionType.Constant && a.GetValue() == 0) return ConstantNode.Zero;

        if (a.Equals(b))
            return new ConstantNode(1);

        if (b.Type == ExpressionType.Constant && Math.Abs(b.GetValue() - 1) < MathD.Epsilon)
            return a;

        return new BinaryOperationNode(this, a, b);
    }
}
