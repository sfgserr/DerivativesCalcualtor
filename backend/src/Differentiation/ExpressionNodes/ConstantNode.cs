using System.Globalization;
using DerivativesCalculator.Differentiation.ExpressionNodeVisitors;
using DerivativesCalculator.Differentiation.Utils;

namespace DerivativesCalculator.Differentiation.ExpressionNodes;

public class ConstantNode : ExpressionNode, IEquatable<ConstantNode>
{
    public ConstantNode(double value)
    {
        Value = value;
    }

    public double Value { get; }

    public override ExpressionType Type => ExpressionType.Constant;

    public static readonly ConstantNode Zero = new ConstantNode(0);

    public override T Accept<T>(IExpressionNodeVisitor<T> visitor) =>
        visitor.Visit(this);

    public override string ToString() =>
        Value.ToString(CultureInfo.InvariantCulture);

    public bool Equals(ConstantNode? node)
    {
        if (node is null) return false;
        return Math.Abs(Value - node.Value) < MathD.Epsilon;
    }

    public override bool Equals(object obj) => Equals(obj as ConstantNode);

    public override int GetHashCode() => Value.GetHashCode();
}
