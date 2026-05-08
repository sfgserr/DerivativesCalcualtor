using DerivativesCalculator.Differentiation.ExpressionNodes;
using DerivativesCalculator.Parsing.Parsers;

namespace DerivativesCalculator.UnitTests.Parsing;

public class PrefixParserTests
{
    [Theory]
    [InlineData("(* (+ 5 (/ (- 12 (* 3 4)) 2)) (- (^ (+ (^ 2 3) (* 6 2)) (/ 1 2)) (/ 42 7)))")]
    [InlineData("(* (sin (+ (^ x 2) (* 3 x))) (ln (exp (+ x 1))))")]
    [InlineData("(/ (tan (* 2 x)) (^ (cos (ln x)) (/ 1 2)))")]
    [InlineData("(+ (exp (* x (ln x))) (sin (^ (cos x) 2)))")]
    [InlineData("(- (cos (^ (+ x 1) 2)) (/ (tan x) (ln (exp (sin x)))))")]
    [InlineData("(* (ln (+ (exp (sin (* 2 x))) 1)) (tan (^ (cos x) (sin x))))")]
    public void PrefixParser_Parses_ComplexExpressionCorrectly(string input)
    {
        ExpressionNode result = PrefixParser.Parse(input);
        Assert.Equal(input, result.ToString());
    }
}
