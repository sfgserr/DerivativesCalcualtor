namespace DerivativesCalculator.Core.Interfaces;

public interface IUseCaseWithResult<TCommand, TResult> where TCommand : ICommandWithResult<TResult>
{
    Task<TResult> Execute(TCommand command);
}
