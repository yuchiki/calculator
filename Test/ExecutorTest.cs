using Calculator;

namespace Test
{
    public class ExecutorTest
    {
        [Fact]
        public void 数値をそのまま返せる()
        {
            Assert.Equal(2, Executor.ExecExpr(new Number(2)));
        }


        [Fact]
        public void 足し算が計算できる()
        {
            Assert.Equal(3, Executor.ExecExpr(new Add(new Number(1), new Number(2))));
        }



        [Fact]
        public void 引き算が計算できる()
        {
            Assert.Equal(3, Executor.ExecExpr(new Sub(new Number(5), new Number(2))));
        }



        [Fact]
        public void かけ算が計算できる()
        {
            Assert.Equal(6, Executor.ExecExpr(new Mul(new Number(2), new Number(3))));
        }



        [Fact]
        public void 割り算が計算できる()
        {
            Assert.Equal(2, Executor.ExecExpr(new Div(new Number(6), new Number(3))));
        }


    }
}
