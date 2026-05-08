using DerivativesCalculator.Core.Contracts;
using DerivativesCalculator.Core.Interfaces;

namespace DerivativesCalculator.Core.UseCases.Differentiate;

public class DifferentiateUseCase : IUseCaseWithResult<DifferentiateCommand, DifferentiateResult>
{
    private readonly IUserContext _user;
    private readonly IDifferentiateService _diffService;

    public DifferentiateUseCase(IUserContext user, IDifferentiateService diffService)
    {
        _user = user;
        _diffService = diffService;
    }

    public Task<DifferentiateResult> Execute(DifferentiateCommand command)
    {
        var diffResult = _diffService.Differentiate(command.Expression);

        return Task.FromResult(_user.IsSubscribed
            ? new DifferentiateResult(diffResult, _diffService.GetStepRecords())
            : new DifferentiateResult(diffResult));
    }
}
