using DerivativesCalculator.Differentiation.ExpressionNodes;

namespace DerivativesCalculator.Differentiation.Extensions;

public static class Extensions
{
    public static double GetValue(this ExpressionNode node)
    {
        if (node is ConstantNode constantNode)
            return constantNode.Value;

        throw new ArgumentException("Node is not a constant");
    }

    public static Dictionary<ExpressionNode, double> CombineForMultiplication(
            this Dictionary<ExpressionNode, double> left,
            Dictionary<ExpressionNode, double> right)
    {
        return left.Concat(right)
            .GroupBy(kvp => kvp.Key, ExpressionNodeComparer.Instance)
            .ToDictionary(
                group => group.Key,
                group => group.Key == ConstantNode.Zero
                    ? group.Select(kvp => kvp.Value).Aggregate((x, y) => x * y)
                    : group.Select(kvp => kvp.Value).Sum()
            );
    }

    public static Dictionary<ExpressionNode, double> CombineForDivision(
        this Dictionary<ExpressionNode, double> left,
        Dictionary<ExpressionNode, double> right)
    {
        return left.Concat(right.Select(kvp => new KeyValuePair<ExpressionNode, double>(kvp.Key, -kvp.Value)))
            .Where(kvp => !kvp.Key.Equals(ConstantNode.Zero))
            .GroupBy(kvp => kvp.Key, ExpressionNodeComparer.Instance)
            .ToDictionary(
                group => group.Key,
                group => group.Select(kvp => kvp.Value).Sum()
            );
    }
}
