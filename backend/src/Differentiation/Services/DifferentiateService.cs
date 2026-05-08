using DerivativesCalculator.Core.Contracts;
using DerivativesCalculator.Differentiation.ExpressionNodeVisitors;
using DerivativesCalculator.Differentiation.Parsing;

namespace DerivativesCalculator.Differentiation.Services;

public class DifferentiateService : IDifferentiateService
{
    private readonly DifferentiateVisitor _differentiateVisitor;

    public DifferentiateService(DifferentiateVisitor differentiateVisitor)
    {
        _differentiateVisitor = differentiateVisitor;
    }

    public string Differentiate(string expression)
    {
        var node = PrefixParser.Parse(expression);

        var diff = node.Accept(_differentiateVisitor).ToString();

        return diff;
    }

    public IReadOnlyCollection<StepRecord> GetStepRecords()
    {
        return _differentiateVisitor.StepRecords;
    }
}
