using DerivativesCalculator.Differentiation.ExpressionNodes;

namespace DerivativesCalculator.Differentiation.SimplificationPatterns;

public class PutRightNodeInNumeratorSimplificationPattern : SimplificationPattern
{
    public override bool Matches(BinaryOperationNode node)
    {
        return
            node.Operation.Operator == "*" &&
            node.Right is not BinaryOperationNode { Operation.Operator: "/" } &&
            node.Left is BinaryOperationNode { Operation.Operator: "/" };
    }

    public override ExpressionNode Apply(BinaryOperationNode node)
    {
        var ratio = (BinaryOperationNode)node.Left;
        return node.Right * ratio.Left / ratio.Right;
    }
}
