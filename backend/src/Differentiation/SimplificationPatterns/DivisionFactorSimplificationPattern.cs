using DerivativesCalculator.Differentiation.ExpressionNodes; 
using DerivativesCalculator.Differentiation.ExpressionNodeVisitors;
using DerivativesCalculator.Differentiation.Extensions;
using DerivativesCalculator.Differentiation.Utils;

namespace DerivativesCalculator.Differentiation.SimplificationPatterns;

public class DivisionFactorSimplificationPattern : SimplificationPattern
{
    private readonly ExtractFactorsVisitor _extractFactorsService;

    public DivisionFactorSimplificationPattern(ExtractFactorsVisitor extractFactorsService)
    {
        _extractFactorsService = extractFactorsService;
    }

    public override bool Matches(BinaryOperationNode node)
    {
        return node.Operation.Operator == "/";
    }

    public override ExpressionNode Apply(BinaryOperationNode node)
    {
        var numeratorFactors = node.Left.Accept(_extractFactorsService);
        var denominatorFactors = node.Right.Accept(_extractFactorsService);

        double numeratorConstant = numeratorFactors.GetValueOrDefault(ConstantNode.Zero, 1);
        double denominatorConstant = denominatorFactors.GetValueOrDefault(ConstantNode.Zero, 1);

        var gcd = MathD.Gcd(numeratorConstant, denominatorConstant);
        numeratorConstant /= gcd;
        denominatorConstant /= gcd;

        return BuildFromFactors(
            new ConstantNode(numeratorConstant),
            new ConstantNode(denominatorConstant),
            numeratorFactors.CombineForDivision(denominatorFactors)
        );
    }

    private ExpressionNode BuildFromFactors(ExpressionNode numerator, ExpressionNode denominator, Dictionary<ExpressionNode, double> factors)
    {
        foreach (var kvp in factors)
        {
            if (kvp.Value > 0)
                numerator *= kvp.Key ^ new ConstantNode(kvp.Value);
            else
                denominator *= kvp.Key ^ new ConstantNode(-kvp.Value);
        }

        if (denominator is ConstantNode constDenom && Math.Abs(constDenom.GetValue() - 1) < MathD.Epsilon)
            return numerator;

        return numerator / denominator;
    }
}
