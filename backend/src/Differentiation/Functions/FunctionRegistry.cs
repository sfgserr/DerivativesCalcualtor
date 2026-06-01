namespace DerivativesCalculator.Differentiation.Functions;

public static class FunctionRegistry
{
    private static readonly Dictionary<string, IFunction> Functions = new()
    {
        ["sin"] = new Sin(),
        ["cos"] = new Cos(),
        ["tan"] = new Tan(),
        ["ln"] = new Ln(),
        ["exp"] = new Exp(),
    };

    public static IFunction? GetFunction(string name)
    {
        return Functions.GetValueOrDefault(name);
    }

    public static bool Contains(string name)
    {
        return Functions.TryGetValue(name, out _);
    }
}
