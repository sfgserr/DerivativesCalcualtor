namespace DerivativesCalculator.Differentiation.Parsing.Exceptions;

public class UnknownTokenException : Exception
{
    public UnknownTokenException(string unknownToken)
    {
        UnknownToken = unknownToken;
    }

    public string UnknownToken { get; }

    public override string Message => $"Cannot parse token \"{UnknownToken}\"";
}
