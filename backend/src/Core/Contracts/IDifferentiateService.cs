namespace DerivativesCalculator.Core.Contracts;

public interface IDifferentiateService
{
    string Differentiate(string expression);

    IReadOnlyCollection<StepRecord> GetStepRecords();
}

public class StepRecord
{
    public StepRecord(string expression, string rule)
    {
        Expression = expression;
        Rule = rule;
    }

    public string Expression { get; }

    public string Rule { get; }
}