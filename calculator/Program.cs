Calculator.Lexer lexer = new() { Input = "12+3*456/(7+8)+9" };

lexer.Tokenize().ForEach(Console.WriteLine);
