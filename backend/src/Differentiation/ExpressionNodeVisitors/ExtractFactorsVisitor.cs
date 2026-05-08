using DerivativesCalculator.Differentiation.ExpressionNodes;
using DerivativesCalculator.Differentiation.Extensions;

namespace DerivativesCalculator.Differentiation.ExpressionNodeVisitors;

public class ExtractFactorsVisitor : IExpressionNodeVisitor<Dictionary<ExpressionNode, double>>
{
    public Dictionary<ExpressionNode, double> Visit(ConstantNode node)
    {
        return new Dictionary<ExpressionNode, double>() { [ConstantNode.Zero] = node.GetValue() };
    }

    public Dictionary<ExpressionNode, double> Visit(VariableNode node)
    {
        return new Dictionary<ExpressionNode, double>() { [node] = 1 };
    }

    public Dictionary<ExpressionNode, double> Visit(FunctionNode node)
    {
        return new Dictionary<ExpressionNode, double>() { [node] = 1 };
    }

    public Dictionary<ExpressionNode, double> Visit(BinaryOperationNode node)
    {
        if (node.IsMultiplication)
        {
            var left = node.Left.Accept(this);
            var right = node.Right.Accept(this);

            return left.CombineForMultiplication(right);
        }

        if (node.IsExponentWithConstant)
        {
            return new Dictionary<ExpressionNode, double>()
            {
                [node.Left] = node.Right.GetValue()
            };
        }

        return new Dictionary<ExpressionNode, double>()
        {
            [node] = 1,
        };
    }
}
