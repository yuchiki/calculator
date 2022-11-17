namespace Calculator
{
    public class Executor
    {
        public static int ExecExpr(Expr expr)
        {
            return expr switch
            {
                Number(var num) => num,
                Add(var lhs, var rhs) => ExecExpr(lhs) + ExecExpr(rhs),
                Sub(var lhs, var rhs) => ExecExpr(lhs) - ExecExpr(rhs),
                Mul(var lhs, var rhs) => ExecExpr(lhs) * ExecExpr(rhs),
                Div(var lhs, var rhs) => ExecExpr(lhs) / ExecExpr(rhs),
                _ => throw new NotImplementedException("unreachable"),
            };
        }
    }
}
