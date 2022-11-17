
while (true)
{
    try
    {

        Console.Write("数式を入力してね！ 例: 1+23*4/(5-6) >");

        string? input;

        do
        {
            input = Console.ReadLine();
        } while (input == null);


        Calculator.Lexer lexer = new() { Input = input };
        Calculator.Parser parser = new() { Tokens = lexer.Tokenize().ToArray() };
        Calculator.Expr expr = parser.Parse();

        Console.WriteLine(expr.PrettyPrint);
        Console.WriteLine($"=> {Calculator.Executor.ExecExpr(expr)}");

    }
    catch (Exception e)
    {

        Console.WriteLine(e);
    }


}
