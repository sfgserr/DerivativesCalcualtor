namespace DerivativesCalculator.Differentiation.Services;

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
