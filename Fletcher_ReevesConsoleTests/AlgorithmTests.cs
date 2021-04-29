using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Fletcher_ReevesConsole_12012021;

namespace Fletcher_ReevesConsoleTests
{
    public class AlgorithmTests
    {
        [Fact]
        void GetG()
        {
            var solution = new Algorithm(-2,4);
            
            solution.GetG();

            Assert.Equal(-12, solution.g[0,0]);
            Assert.Equal(6, solution.g[1, 0]);
        }

        [Fact]
        void GetS()
        {
            var solution = new Algorithm(-2,4);
           
            solution.GetG();
            solution.GetS();
            Assert.Equal(12, solution.s[0, 0]);
            Assert.Equal(-6, solution.s[1, 0]);
        }

        [Fact]
        void GetLambda()
        {
            var solution = new Algorithm(-2,4);
           
            solution.GetG();
            solution.GetS();
            solution.GetLambda();
            Assert.Equal(0.2941, solution._lambda,4);
            
        }

        [Fact]
        void GetNextPoint1()
        {
            var solution = new Algorithm(-2,4);
            
            solution.GetG();
            solution.GetS();
            solution.GetLambda();
            solution.GetNextPoint1();
            Assert.Equal(1.5294, solution.x[0, 0], 4);
            Assert.Equal(2.2353, solution.x[1, 0], 4);
        }

        [Fact]
        void GetGNext()
        {
            var solution = new Algorithm(-2, 4);

            solution.GetG();
            solution.GetS();
            solution.GetLambda();
            solution.GetNextPoint1();
            solution.GetGNext();
            Assert.Equal(0.3529, solution.gNext[0, 0], 4);
            Assert.Equal(0.7059, solution.gNext[1, 0], 4);
        }

        [Fact]
        void BufferTest()
        {
            var solution = new Algorithm(-2, 4);

            solution.GetG();
            solution.GetS();
            solution.GetLambda();
            solution.GetNextPoint1();
            solution.GetGNext();
            solution.GetSNext();
            Assert.Equal(-0.3114, solution.sNext[0, 0], 4);
            Assert.Equal(-0.7266, solution.sNext[1, 0], 4);
        }

        [Fact]
        void GetLambda2()
        {
            var solution = new Algorithm(-2, 4);

            solution.GetG();
            solution.GetS();
            solution.GetLambda();
            solution.GetNextPoint1();
            solution.GetGNext();
            solution.GetSNext();
            solution.GetLambda2();
            Assert.Equal(1.70, solution._lambda2, 2);
            
        }

        [Fact]
        void GetNextPoint2()
        {
            var solution = new Algorithm(-2, 4);

            solution.GetG();
            solution.GetS();
            solution.GetLambda();
            solution.GetNextPoint1();
            solution.GetGNext();
            solution.GetSNext();
            solution.GetLambda2();
            solution.GetNextPoint2();
            Assert.Equal(1.00000, solution.x[0, 0], 5);
            Assert.Equal(1.00000, solution.x[1, 0], 5);
        }

        [Fact]
        void GetGNext2()
        {
            var solution = new Algorithm(-2, 4);

            solution.GetG();
            solution.GetS();
            solution.GetLambda();
            solution.GetNextPoint1();
            solution.GetGNext();
            solution.GetSNext();
            solution.GetLambda2();
            solution.GetNextPoint2();
            solution.GetGNext();
            Assert.Equal(0.00000, solution.gNext[0, 0],5);
            Assert.Equal(0.00000, solution.gNext[1, 0],5);
        }

        [Fact]
        void GradCheck()
        {
            var solution = new Algorithm(-2, 4);

            solution.GetG();
            solution.GetS();
            solution.GetLambda();
            solution.GetNextPoint1();
            solution.GetGNext();
            solution.GetSNext();
            solution.GetLambda2();
            solution.GetNextPoint2();
            solution.GetGNext();
            solution.GradientCheck();
            Assert.True(solution.isMinimum);
            
        }
    }
}
