namespace Calculator
{
    public abstract record Token;
    public record Number(int Num) : Token;
    public record Plus : Token;
    public record Minus : Token;
    public record Asterisk : Token;
    public record Slash : Token;
    public record LParen : Token;
    public record RParen : Token;
}
