using DerivativesCalculator.Core.Contracts;

namespace DerivativesCalculator.WebApi.Authentication;

public class UserContext : IUserContext
{
    public Guid Id => Guid.NewGuid();

    public bool IsSubscribed => true;
}
