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
        var derivative = DifferentiateFunction(node);

        var result = (node.Body.Accept(this) * derivative).Accept(_simplificationService);

        _stepRecords.Add(new StepRecord(result.ToString(), "Chain Rule: d/dx(f(g(x))) = f'(g(x)) * g'(x)"));

        return result;
    }

    private ExpressionNode DifferentiateFunction(FunctionNode node) => node.Function switch
    {
        "exp" => node,
        "cos" => new ConstantNode(-1) * new FunctionNode("sin", node.Body),
        "sin" => new FunctionNode("cos", node.Body),
        "ln" => new ConstantNode(1) / node.Body,
        "tan" => new ConstantNode(1) / (new FunctionNode("cos", node.Body) ^ new ConstantNode(2)),
        _ => throw new NotImplementedException()
    };
}
