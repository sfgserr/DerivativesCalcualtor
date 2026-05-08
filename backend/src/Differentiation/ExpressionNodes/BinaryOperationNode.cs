using DerivativesCalculator.Differentiation.ExpressionNodeVisitors;
using DerivativesCalculator.Differentiation.BinaryOperations;

namespace DerivativesCalculator.Differentiation.ExpressionNodes;

public class BinaryOperationNode : ExpressionNode
{
    public BinaryOperationNode(IBinaryOperation operation, ExpressionNode left, ExpressionNode right)
    {
        Operation = operation;

        Left = left;
        Right = right;
    }

    public IBinaryOperation Operation { get; }

    public ExpressionNode Left { get; }

    public ExpressionNode Right { get; }

    public bool IsMultiplication => Operation.Operator == "*";

    public bool IsExponentWithConstant => Operation.Operator == "^" && Right.Type == ExpressionType.Constant;

    public override T Accept<T>(IExpressionNodeVisitor<T> visitor) =>
        visitor.Visit(this);

    public override ExpressionType Type => ExpressionType.Binary;

    public override string ToString() =>
        $"({Operation.Operator} {Left.ToString()} {Right.ToString()})";

    public override bool Equals(object obj)
    {
        if (obj is not BinaryOperationNode other)
            return false;

        if (!other.Operation.Operator.Equals(Operation.Operator)) return false;

        if (Operation.IsCommutative)
        {
            var left = Left.Equals(other.Left) || Left.Equals(other.Right);
            var right = Right.Equals(other.Left) || Right.Equals(other.Right);

            return left && right;
        }

        return Left.Equals(other.Left) && Right.Equals(other.Right);
    }

    public override int GetHashCode()
    {
        var hash = Operation.Operator.GetHashCode();

        if (Operation.IsCommutative)
        {
            var left = Left.GetHashCode();
            var right = Right.GetHashCode();
            var combined = left > right ?
                HashCode.Combine(left, right) :
                HashCode.Combine(right, left);

            return HashCode.Combine(hash, combined);
        }

        return HashCode.Combine(hash, Left.GetHashCode(), Right.GetHashCode());
    }
}
