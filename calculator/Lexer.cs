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
                switch (Input)
                {
                    case [' ', .. var rest]:
                        Input = rest;
                        break;
                    case [>= '0' and <= '9', ..]:
                        (int value, int length) = ReadNumber();
                        tokens.Add(new TNumber(value));
                        Input = Input[length..];
                        break;
                    case ['+', .. var rest]:
                        tokens.Add(new Plus());
                        Input = rest;
                        break;
                    case ['-', .. var rest]:
                        tokens.Add(new Minus());
                        Input = rest;
                        break;
                    case ['*', .. var rest]:
                        tokens.Add(new Asterisk());
                        Input = rest;
                        break;
                    case ['/', .. var rest]:
                        tokens.Add(new Slash());
                        Input = rest;
                        break;
                    case ['(', .. var rest]:
                        tokens.Add(new LParen());
                        Input = rest;
                        break;
                    case [')', .. var rest]:
                        tokens.Add(new RParen());
                        Input = rest;
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

