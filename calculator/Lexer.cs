namespace Calculator
{
    public class Lexer
    {
        public required string Input { get; set; }

        public List<Token> Tokenize()
        {
            List<Token> tokens = new();

            while (Input.Length > 0)
            {
                switch (Input[0])
                {
                    case ' ':
                        Input = Input[1..];
                        break;
                    case >= '0' and <= '9':
                        (int value, int length) = ReadNumber();
                        tokens.Add(new Number(value));
                        Input = Input[length..];
                        break;
                    case '+':
                        tokens.Add(new Plus());
                        Input = Input[1..];
                        break;
                    case '-':
                        tokens.Add(new Minus());
                        Input = Input[1..];
                        break;
                    case '*':
                        tokens.Add(new Asterisk());
                        Input = Input[1..];
                        break;
                    case '/':
                        tokens.Add(new Slash());
                        Input = Input[1..];
                        break;
                    case '(':
                        tokens.Add(new LParen());
                        Input = Input[1..];
                        break;
                    case ')':
                        tokens.Add(new RParen());
                        Input = Input[1..];
                        break;
                    default:
                        throw new Exception($"parse error: unexpected '{Input[0]}'");
                }
            }

            return tokens;
        }

        /// (value, length)
        private (int, int) ReadNumber()
        {
            int length = 0;
            int value = 0;

            while (length < Input.Length && Input[length] is >= '0' and <= '9')
            {
                value = (value * 10) + (Input[length] - '0');
                length++;
            }

            return (value, length);
        }
    }
}

