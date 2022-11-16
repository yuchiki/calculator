using Calculator;

namespace Test
{
    public class ParserTest
    {
        [Fact]
        public void 数字がパースできる()
        {
            Assert.Equal(new Parser { Tokens = new Token[] { new TNumber(1) } }.Parse(), new Number(1));
        }

        [Fact]
        public static void 足し算がパースできる()
        {
            Assert.Equal(new Parser { Tokens = new Token[] { new TNumber(1), new Plus(), new TNumber(2) } }.Parse()
            , new Add(new Number(1), new Number(2)));
        }
        [Fact]
        public static void 引き算がパースできる()
        {
            Assert.Equal(new Parser { Tokens = new Token[] { new TNumber(1), new Minus(), new TNumber(2) } }.Parse()
            , new Sub(new Number(1), new Number(2)));
        }
        [Fact]
        public static void かけ算がパースできる()
        {
            Assert.Equal(new Parser { Tokens = new Token[] { new TNumber(1), new Asterisk(), new TNumber(2) } }.Parse()
            , new Mul(new Number(1), new Number(2)));
        }
        [Fact]
        public static void 割り算がパースできる()
        {
            Assert.Equal(new Parser { Tokens = new Token[] { new TNumber(1), new Slash(), new TNumber(2) } }.Parse()
            , new Div(new Number(1), new Number(2)));
        }

        [Fact]
        public static void かっこがパースできる()
        {
            Assert.Equal(new Parser { Tokens = new Token[] { new LParen(), new TNumber(1), new RParen() } }.Parse()
            , new Number(1));
        }

    }
}
