using DerivativesCalculator.Differentiation.ExpressionNodes;
using DerivativesCalculator.Differentiation.SimplificationPatterns;

namespace DerivativesCalculator.Differentiation.ExpressionNodeVisitors;

public class SimplificationVisitor : IExpressionNodeVisitor<ExpressionNode>
{
    private readonly IEnumerable<SimplificationPattern> _patterns;

    public SimplificationVisitor(IEnumerable<SimplificationPattern> patterns)
    {
        _patterns = patterns;
    }

    public ExpressionNode Visit(ConstantNode node) => node;

    public ExpressionNode Visit(VariableNode node) => node;

    public ExpressionNode Visit(BinaryOperationNode node)
    {
        var left = node.Left.Accept(this);
        var right = node.Right.Accept(this);

        var toSimplify = new BinaryOperationNode(node.Operation, left, right);

        return ApplyPattern(toSimplify);
    }

    public ExpressionNode Visit(FunctionNode node) =>
        new FunctionNode(node.Function, node.Body.Accept(this));

    private ExpressionNode ApplyPattern(BinaryOperationNode node)
    {
        ExpressionNode simplifiedNode = node;
        foreach (var pattern in _patterns)
        {
            if (simplifiedNode is BinaryOperationNode sbn && pattern.Matches(sbn))
            {
                simplifiedNode = pattern.Apply(sbn);
            }
        }

        return simplifiedNode;
    }
}
