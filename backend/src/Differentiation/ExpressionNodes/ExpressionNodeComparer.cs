namespace DerivativesCalculator.Differentiation.ExpressionNodes;

class ExpressionNodeComparer : IEqualityComparer<ExpressionNode>
{
    public static readonly ExpressionNodeComparer Instance = new();

    private ExpressionNodeComparer() { }

    public bool Equals(ExpressionNode? a, ExpressionNode? b)
    {
        if (a == null && b == null) return true;
        if (a == null || b == null) return false;

        return a.Equals(b);
    }

    public int GetHashCode(ExpressionNode? node)
    {
        return node?.GetHashCode() ?? 0;
    }
}
