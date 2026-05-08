using DerivativesCalculator.Differentiation.ExpressionNodes;

namespace DerivativesCalculator.Differentiation.BinaryOperations;

public interface IBinaryOperation
{
    string Operator { get; }

    bool IsCommutative { get; }
    
    string DifferentiateRule { get; }
    
    ExpressionNode Differentiate(ExpressionNode a, ExpressionNode b,
        ExpressionNode aDiff, ExpressionNode bDiff);

    ExpressionNode Evaluate(ExpressionNode a, ExpressionNode b);
}
