namespace DerivativesCalculator.Differentiation.Utils;

public static class MathD
{
    public const double Epsilon = 1E-9;

    public static double Gcd(double a, double b)
    {
        while (b != 0)
        {
            double temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }
}