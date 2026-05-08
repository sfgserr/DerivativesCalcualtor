using DerivativesCalculator.Differentiation.ExpressionNodes;

namespace DerivativesCalculator.Differentiation.SimplificationPatterns;

public class PutLeftNodeInNumeratorSimplificationPattern : SimplificationPattern
{
    public override bool Matches(BinaryOperationNode node)
    {
        return
            node.Operation.Operator == "*" &&
            node.Left is not BinaryOperationNode { Operation.Operator: "/" } &&
            node.Right is BinaryOperationNode { Operation.Operator: "/" };
    }

    public override ExpressionNode Apply(BinaryOperationNode node)
    {
        var ratio = (BinaryOperationNode)node.Right;
        return node.Left * ratio.Left / ratio.Right;
    }
}

