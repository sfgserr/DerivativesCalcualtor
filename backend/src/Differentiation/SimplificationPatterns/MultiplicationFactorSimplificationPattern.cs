using DerivativesCalculator.Differentiation.ExpressionNodes;
using DerivativesCalculator.Differentiation.ExpressionNodeVisitors;

namespace DerivativesCalculator.Differentiation.SimplificationPatterns;

public class MultiplicationFactorSimplificationPattern : SimplificationPattern
{
    private readonly ExtractFactorsVisitor _extractFactorsService;

    public MultiplicationFactorSimplificationPattern(ExtractFactorsVisitor extractFactorsService)
    {
        _extractFactorsService = extractFactorsService;
    }

    public override bool Matches(BinaryOperationNode node)
    {
        return node.Operation.Operator == "*";
    }

    public override ExpressionNode Apply(BinaryOperationNode node)
    {
        var factors = node.Accept(_extractFactorsService);

        return BuildFromFactors(factors);
    }

    private ExpressionNode BuildFromFactors(Dictionary<ExpressionNode, double> factors)
    {
        ExpressionNode? result = null;

        foreach (var kvp in factors)
        {
            var factorNode = kvp.Key == ConstantNode.Zero
                ? new ConstantNode(kvp.Value)
                : kvp.Key ^ new ConstantNode(kvp.Value);

            result = result == null
                ? factorNode
                : result * factorNode;
        }

        return result!;
    }
}
