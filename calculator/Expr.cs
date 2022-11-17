namespace Calculator
{
    public abstract record Expr;
    public record Number(int Num) : Expr;
    public record Add(Expr Lhs, Expr Rhs) : Expr;
    public record Sub(Expr Lhs, Expr Rhs) : Expr;
    public record Mul(Expr Lhs, Expr Rhs) : Expr;
    public record Div(Expr Lhs, Expr Rhs) : Expr;

    internal static class Indenter
    {

        public static string Indent(string str)
        {
            return string.Join('\n', str.Split("\n").Where(s => s.Length != 0).Select(s => "  " + s)) + '\n';
        }
    }

    public static class PrettyPrinter
    {
        public static string PrettyPrint(Expr e)
        {
            return e switch
            {
                Number(var n) => $"{n}\n",
                Add(var lhs, var rhs) => "+\n" + Indenter.Indent("左:" + PrettyPrint(lhs)) + Indenter.Indent("右:" + PrettyPrint(rhs)),
                Sub(var lhs, var rhs) => "-\n" + Indenter.Indent("左:" + PrettyPrint(lhs)) + Indenter.Indent("右:" + PrettyPrint(rhs)),
                Mul(var lhs, var rhs) => "*\n" + Indenter.Indent("左:" + PrettyPrint(lhs)) + Indenter.Indent("右:" + PrettyPrint(rhs)),
                Div(var lhs, var rhs) => "/\n" + Indenter.Indent("左:" + PrettyPrint(lhs)) + Indenter.Indent("右:" + PrettyPrint(rhs)),
                _ => throw new NotImplementedException(),
            };
        }
    }
}

