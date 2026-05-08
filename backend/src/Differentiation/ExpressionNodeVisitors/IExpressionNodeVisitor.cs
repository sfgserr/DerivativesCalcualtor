using DerivativesCalculator.Differentiation.ExpressionNodes;

namespace DerivativesCalculator.Differentiation.ExpressionNodeVisitors;

public interface IExpressionNodeVisitor<out T>
{
    T Visit(ConstantNode node);

    T Visit(VariableNode node);

    T Visit(BinaryOperationNode node);

    T Visit(FunctionNode node);
}
