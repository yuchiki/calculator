namespace Calculator
{
    public class Lexer
    {
        public required string RawString { private get; init; }
        private int Position { get; set; }

        public List<Token> Tokenize()
        {
            List<Token> tokens = new();

            while (Position < RawString.Length)
            {
                switch (RawString[Position])
                {
                    case ' ':
                        Position++;
                        break;
                    case >= '0' and <= '9':
                        (int value, int length) = ReadNumber();
                        tokens.Add(new Number(value));
                        Position += length;
                        break;
                    case '+':
                        tokens.Add(new Plus());
                        Position++;
                        break;
                    case '-':
                        tokens.Add(new Minus());
                        Position++;
                        break;
                    case '*':
                        tokens.Add(new Asterisk());
                        Position++;
                        break;
                    case '/':
                        tokens.Add(new Slash());
                        Position++;
                        break;
                    case '(':
                        tokens.Add(new LParen());
                        Position++;
                        break;
                    case ')':
                        tokens.Add(new RParen());
                        Position++;
                        break;
                    default:
                        throw new Exception($"parse error: unexpected '{tokens[Position]}'");
                }
            }

            return tokens;
        }

        /// (value, length)
        private (int, int) ReadNumber()
        {
            int length = 0;
            int value = 0;

            while (Position + length < RawString.Length && RawString[Position + length] is >= '0' and <= '9')
            {
                value = (value * 10) + (RawString[Position + length] - '0');
                length++;
            }

            return (value, length);
        }
    }
}

