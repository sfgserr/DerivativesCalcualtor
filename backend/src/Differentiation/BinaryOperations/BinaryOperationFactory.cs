using DerivativesCalculator.Differentiation.ExpressionNodes;

namespace DerivativesCalculator.Differentiation.BinaryOperations;

public static class BinaryOperationFactory
{
    private static readonly Dictionary<string, IBinaryOperation> _operations = new()
    {
        ["+"] = new Addition(),
        ["-"] = new Subtraction(),
        ["*"] = new Multiplication(),
        ["/"] = new Division(),
        ["^"] = new Pow()
    };

    public static ExpressionNode Evaluate(string op, ExpressionNode left, ExpressionNode right)
    {
        if (_operations.TryGetValue(op, out var operation))
        {
            return operation.Evaluate(left, right);
        }

        throw new ArgumentException();
    }

    public static IBinaryOperation Get(string op)
    {
        return _operations.TryGetValue(op, out var operation) ? operation : throw new ArgumentException();
    }
}
