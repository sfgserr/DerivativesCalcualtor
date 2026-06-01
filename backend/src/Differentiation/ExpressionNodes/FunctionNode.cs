using DerivativesCalculator.Differentiation.ExpressionNodeVisitors;
using DerivativesCalculator.Differentiation.Functions;

namespace DerivativesCalculator.Differentiation.ExpressionNodes;

public class FunctionNode : ExpressionNode
{
    public FunctionNode(IFunction function, ExpressionNode body)
    {
        Function = function;
        Body = body;
    }

    public override ExpressionType Type => ExpressionType.Function;

    public IFunction Function { get; }

    public ExpressionNode Body { get; }

    public override T Accept<T>(IExpressionNodeVisitor<T> visitor) =>
        visitor.Visit(this);

    public override string ToString()
    {
        return $"({Function} {Body.ToString()})";
    }

    public override bool Equals(object obj)
    {
        if (obj is not FunctionNode other)
            return false;

        return other.Function.Equals(Function) &&
            other.Body.Equals(Body);
    }

    public override int GetHashCode() => HashCode.Combine(Function.GetHashCode(), Body.GetHashCode());
}
