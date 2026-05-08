using DerivativesCalculator.Differentiation.ExpressionNodes;

namespace DerivativesCalculator.Differentiation.SimplificationPatterns;

public class BothNodesAreRatiosSimplificationPattern : SimplificationPattern
{
    public override bool Matches(BinaryOperationNode node)
    {
        return
            node.Operation.Operator == "/" &&
            node.Left is BinaryOperationNode { Operation.Operator: "/" } &&
            node.Right is BinaryOperationNode { Operation.Operator: "/" };
    }

    public override ExpressionNode Apply(BinaryOperationNode node)
    {
        var left = (BinaryOperationNode)node.Left;
        var right = (BinaryOperationNode)node.Right;

        return left.Left * right.Left / (left.Right * right.Right);
    }
}
