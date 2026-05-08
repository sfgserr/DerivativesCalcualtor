using DerivativesCalculator.Differentiation.ExpressionNodeVisitors;

namespace DerivativesCalculator.Differentiation.ExpressionNodes;

public class VariableNode : ExpressionNode
{
    public override ExpressionType Type => ExpressionType.Variable;

    public override T Accept<T>(IExpressionNodeVisitor<T> visitor) =>
        visitor.Visit(this);

    public override string ToString() => "x";

    public override bool Equals(object obj) => obj is VariableNode;

    public override int GetHashCode() => "x".GetHashCode();
}
