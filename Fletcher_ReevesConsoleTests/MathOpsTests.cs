using Fletcher_ReevesConsole_12012021;
using System;
using Xunit;

namespace Fletcher_ReevesConsoleTests
{
    public class MathOpsTests
    {
        [Fact]
        public void DiffWrtX1()
        {
            var value = MathOps.DifferentiateWrtX1(1.5, -2, -1, 0, 0.5, 0, -2, 4);

            Assert.Equal(-12, value, 1);
        }

        [Fact]
        public void DiffWrtX2()
        {
            var value = MathOps.DifferentiateWrtX2(1.5, -2, -1, 0, 0.5, 0, -2, 4);

            Assert.Equal(6, value, 1);
        }

        [Fact]
        public void MatriXNegatOneTest()
        {
            double[,] m = new double[,] { { -12 }, { 6 } };

            var value = MathOps.MatriXNegativeOne(m);

            Assert.Equal(12, value[0, 0]);
            Assert.Equal(-6, value[1, 0]);
        }

        [Fact]
        public void AddMatricesTest()
        {
            double[,] m = MathOps.AddMatrices(new double[,] { { 0 }, { -0.6957 } }, new double[,] { { 0.242 }, { 0 } });

            Assert.Equal(0.242, m[0, 0]);
            Assert.Equal(-0.6957, m[1, 0]);
        }

        [Fact]
        public void TransposeMatrixTest()
        {
            double[,] m = new double[,] { { -12 }, { 6 } };

            var value = MathOps.TransposeMatrix(m);

            Assert.Equal(-12, value[0, 0]);
            Assert.Equal(6, value[0, 1]);
        }

        [Fact]
        public void MatriXScalarTest()
        {
            double[,] m = new double[,] { { -12 }, { 6 } };

            var value = MathOps.MultiplyMatrixByScalar(m, -1);

            Assert.Equal(12, value[0, 0]);
            Assert.Equal(-6, value[1, 0]);
        }

        [Fact]
        public void MatriXMatrixTest()
        {
            var value = MathOps.MultiplyMatrixByMatrix(new double[,] { { 2, 1 } }, new double[,] { { 2 }, { 1 } });

            Assert.Equal(5, value);

        }
    }
}
