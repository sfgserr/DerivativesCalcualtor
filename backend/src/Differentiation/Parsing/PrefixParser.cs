using System.Text;
using System.Globalization;
using DerivativesCalculator.Differentiation.ExpressionNodes;
using DerivativesCalculator.Differentiation.BinaryOperations;
using DerivativesCalculator.Differentiation.Functions;
using DerivativesCalculator.Differentiation.Parsing.Exceptions;

namespace DerivativesCalculator.Differentiation.Parsing;

public static class PrefixParser
{
    public static ExpressionNode Parse(string input)
    {
        int current = 0;
        StringBuilder builder = new StringBuilder();
        Stack<ExpressionNode> builtNodes = new Stack<ExpressionNode>();
        Stack<string> operators = new Stack<string>();

        void FlushToken()
        {
            if (builder.Length == 0) return;
            string token = builder.ToString();
            builder.Clear();

            if (BinaryOperationFactory.Contains(token) || FunctionRegistry.Contains(token))
            {
                operators.Push(token);
            }
            else
            {
                ExpressionNode node = token == "x" ? new VariableNode() :
                    double.TryParse(token, CultureInfo.InvariantCulture, out var value) ? new ConstantNode(value) :
                    throw new UnknownTokenException(token);

                builtNodes.Push(node);
            }
        }

        while (current < input.Length)
        {
            char c = input[current++];

            switch (c)
            {
                case '(':
                    break;
                case ' ':
                    FlushToken();
                    break;
                case ')':
                    FlushToken();
                    string op = operators.Pop();
                    if (BinaryOperationFactory.Contains(op))
                    {
                        var right = builtNodes.Pop();
                        var left = builtNodes.Pop();

                        builtNodes.Push(new BinaryOperationNode(BinaryOperationFactory.Get(op), left, right));
                    }
                    else
                    {
                        builtNodes.Push(new FunctionNode(FunctionRegistry.GetFunction(op)!, builtNodes.Pop()));
                    }
                    break;
                default:
                    builder.Append(c);
                    break;
            }
        }

        FlushToken();
        return builtNodes.Pop();
    }
}