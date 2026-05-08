namespace DerivativesCalculator.Core.Interfaces;

public interface IUseCase<TCommand> where TCommand : ICommand
{
    Task Execute(TCommand command);
}
