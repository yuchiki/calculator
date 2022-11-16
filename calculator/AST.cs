namespace Calculator
{
    public abstract record Expr
    {
        public abstract string PrettyPrint { get; }
    };
    public record Number(int Num) : Expr
    {
        public override string PrettyPrint => $"{Num}\n";
    };
    public record Add(Expr Lhs, Expr Rhs) : Expr
    {
        public override string PrettyPrint =>
            "+\n" + Indenter.Indent(Lhs.PrettyPrint) + Indenter.Indent(Rhs.PrettyPrint);
    };
    public record Sub(Expr Lhs, Expr Rhs) : Expr
    {
        public override string PrettyPrint =>
    "-\n" + Indenter.Indent(Lhs.PrettyPrint) + Indenter.Indent(Rhs.PrettyPrint);

    };
    public record Mul(Expr Lhs, Expr Rhs) : Expr
    {
        public override string PrettyPrint =>
    "*\n" + Indenter.Indent(Lhs.PrettyPrint) + Indenter.Indent(Rhs.PrettyPrint);

    }
    public record Div(Expr Lhs, Expr Rhs) : Expr
    {
        public override string PrettyPrint =>
    "/\n" + Indenter.Indent(Lhs.PrettyPrint) + Indenter.Indent(Rhs.PrettyPrint);

    }

    internal static class Indenter
    {

        public static string Indent(string str)
        {
            return string.Join('\n', str.Split("\n").Where(s => s.Length != 0).Select(s => "  " + s)) + '\n';
        }
    }
}
