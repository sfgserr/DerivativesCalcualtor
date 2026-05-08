namespace DerivativesCalculator.Core.Contracts;

public interface IUserContext
{
    public Guid Id { get; }

    public bool IsSubscribed { get; }
}
