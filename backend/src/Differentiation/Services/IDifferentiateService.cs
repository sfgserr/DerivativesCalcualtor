namespace DerivativesCalculator.Differentiation.Services;

public interface IDifferentiateService
{
    string Differentiate(string expression);

    IReadOnlyCollection<StepRecord> GetStepRecords();
}
