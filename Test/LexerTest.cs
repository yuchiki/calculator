using Calculator;

namespace Test
{
    public class LexerTest
    {
        [Fact]
        public void 数字がtokenizeできる()
        {
            Assert.Equal(new Lexer { Input = "123" }.Tokenize()[0], new TNumber(123));
        }

        [Fact]
        public void プラスがtokenizeできる()
        {
            Assert.Equal(new Lexer { Input = "+" }.Tokenize()[0], new Plus());
        }

        [Fact]
        public void マイナスがtokenizeできる()
        {
            Assert.Equal(new Lexer { Input = "-" }.Tokenize()[0], new Minus());
        }
        [Fact]
        public void アスタリスクがtokenizeできる()
        {
            Assert.Equal(new Lexer { Input = "*" }.Tokenize()[0], new Asterisk());
        }
        [Fact]
        public void スラッシュがtokenizeできる()
        {
            Assert.Equal(new Lexer { Input = "/" }.Tokenize()[0], new Slash());
        }
        [Fact]
        public void 左かっこがtokenizeできる()
        {
            Assert.Equal(new Lexer { Input = "(" }.Tokenize()[0], new LParen());
        }
        [Fact]
        public void 右かっこがtokenizeできる()
        {
            Assert.Equal(new Lexer { Input = ")" }.Tokenize()[0], new RParen());
        }
        [Fact]
        public void 空白が入っていてもtokenizeできる()
        {
            Assert.Equal(new Lexer { Input = "1 + 2" }.Tokenize(),
       new Token[]{
                new TNumber(1), new Plus(), new TNumber(2)
        });
        }

        [Fact]
        public static void 複雑な式をtokenizeできる()
        {
            Assert.Equal(new Lexer { Input = "12 + 3 * 456 / (7 + 8) + 9" }.Tokenize(),
            new Token[]{
                new TNumber(12),
                new Plus(),
                new TNumber(3),
                new Asterisk(),
                new TNumber(456),
                new Slash(),
                new LParen(),
                new TNumber(7),
                new Plus(),
                new TNumber(8),
                new RParen(),
                new Plus(),
                new TNumber(9)
            });
        }
    }
}
