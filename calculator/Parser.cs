namespace Calculator
{
    public class Parser
    {
        public required Token[] Tokens { get; set; }


        public Expr Parse()
        {
            Expr expr = ParseExpr();

            return Tokens.Length > 0 ? throw new Exception($"余計なトークンが末尾に存在している: {Tokens}") : expr;
        }

        private Expr ParseExpr()
        {
            return ParseAddSub();
        }

        private Expr ParseAddSub()
        {
            Expr lhs = ParseMulDiv();

            switch (Tokens)
            {
                case [Plus, .. var rest]:
                    {
                        Tokens = rest;
                        Expr rhs = ParseAddSub();
                        return new Add(lhs, rhs);
                    }
                case [Minus, .. var rest]:
                    {
                        Tokens = rest;
                        Expr rhs = ParseAddSub();
                        return new Sub(lhs, rhs);
                    }
                default:
                    return lhs;
            }
        }

        private Expr ParseMulDiv()
        {
            Expr lhs = ParseNumParen();

            switch (Tokens)
            {
                case [Asterisk, .. var rest]:
                    {
                        Tokens = rest;
                        Expr rhs = ParseMulDiv();
                        return new Mul(lhs, rhs);
                    }
                case [Slash, .. var rest]:
                    {
                        Tokens = rest;
                        Expr rhs = ParseMulDiv();
                        return new Div(lhs, rhs);
                    }
                default:
                    return lhs;
            }
        }

        private Expr ParseNumParen()
        {
            switch (Tokens)
            {
                case [TNumber(var num), .. var rest]:
                    Tokens = rest;
                    return new Number(num);
                case [LParen, .. var rest]:
                    Tokens = rest;
                    Expr expr = ParseExpr();

                    switch (Tokens)
                    {
                        case [RParen, .. var rest2]:
                            Tokens = rest2;
                            return expr;
                        default:
                            throw new Exception("')'が足りない.");
                    }
                default:
                    throw new Exception("unreachable");
            }
        }

    }
}
