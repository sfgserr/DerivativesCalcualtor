using DerivativesCalculator.Differentiation.ExpressionNodes;
using DerivativesCalculator.Core.Contracts;

namespace DerivativesCalculator.Differentiation.ExpressionNodeVisitors;

public class DifferentiateVisitor : IExpressionNodeVisitor<ExpressionNode>
{
    private readonly SimplificationVisitor _simplificationService;
    private readonly List<StepRecord> _stepRecords = new();

    public DifferentiateVisitor(SimplificationVisitor simplificationService)
    {
        _simplificationService = simplificationService;
    }

    public IReadOnlyCollection<StepRecord> StepRecords => _stepRecords.AsReadOnly();

    public ExpressionNode Visit(ConstantNode node) =>
        ConstantNode.Zero;

    public ExpressionNode Visit(VariableNode node) =>
        new ConstantNode(1);

    public ExpressionNode Visit(BinaryOperationNode node)
    {
        ExpressionNode leftDerivative = node.Left.Accept(this);
        ExpressionNode rightDerivative = node.Right.Accept(this);

        var diff = node.Operation.Differentiate(
            node.Left,
            node.Right,
            leftDerivative,
            rightDerivative).Accept(_simplificationService);

        _stepRecords.Add(new StepRecord(diff.ToString(), node.Operation.DifferentiateRule));

        return diff;
    }

    public ExpressionNode Visit(FunctionNode node)
    {
        var derivative = node.Function.Differentiate(node.Body);

        var result = (node.Body.Accept(this) * derivative).Accept(_simplificationService);

        _stepRecords.Add(new StepRecord(result.ToString(), "Chain Rule: d/dx(f(g(x))) = f'(g(x)) * g'(x)"));

        return result;
    }
}
