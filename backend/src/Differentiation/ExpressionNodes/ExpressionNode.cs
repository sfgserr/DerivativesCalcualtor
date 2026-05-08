using DerivativesCalculator.Differentiation.ExpressionNodeVisitors;
using DerivativesCalculator.Differentiation.BinaryOperations;

namespace DerivativesCalculator.Differentiation.ExpressionNodes;

public enum ExpressionType
{
    Constant,
    Variable,
    Binary,
    Function
}

public abstract class ExpressionNode
{
    public abstract ExpressionType Type { get; }

    public abstract T Accept<T>(IExpressionNodeVisitor<T> visitor);

    public new abstract string ToString();

    public new abstract bool Equals(object obj);

    public static ExpressionNode operator +(ExpressionNode left, ExpressionNode right) => BinaryOperationFactory.Evaluate("+", left, right);

    public static ExpressionNode operator -(ExpressionNode left, ExpressionNode right) => BinaryOperationFactory.Evaluate("-", left, right);

    public static ExpressionNode operator *(ExpressionNode left, ExpressionNode right) => BinaryOperationFactory.Evaluate("*", left, right);

    public static ExpressionNode operator /(ExpressionNode left, ExpressionNode right) => BinaryOperationFactory.Evaluate("/", left, right);

    public static ExpressionNode operator ^(ExpressionNode left, ExpressionNode right) => BinaryOperationFactory.Evaluate("^", left, right);
}
