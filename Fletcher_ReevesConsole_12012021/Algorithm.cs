using System;
using System.Collections.Generic;
using System.Text;

namespace Fletcher_ReevesConsole_12012021
{
    public class Algorithm
    {
        public Algorithm(double x1,double x2)
        {
            Console.WriteLine("****************************FLETCHER_REEVES SOLUTION**************************");
            Console.WriteLine();
            Console.WriteLine("FOR A QUESTION OF THE FORM AX1^2 + BX1 + CX1X2 + DX2 + EX2^2 + F");
            Console.WriteLine();
            a = 1.5;
            b = -2;
            c = -1;
            d = 0;
            e = 0.5;
            f = 0;
            g = new double[2, 1];
            s = new double[2, 1];
            gNext = new double[2, 1];
            x = new double[2, 1];
            x[0, 0] = x1;
            x[1, 0] = x2;
            isMinimum = false;
            buffer = 0;
        }

        const double tolerance = 0.005;
        double a;
        double b;
        double c;
        double d;
        double e;
        double f;
        public double[,] gNext;
        public double[,] sNext;
        public double _lambda;
        public double _lambda2;

        public double[,] x;
      
        public double[,] g;
        //i removed the property so that it doesn't keep calling gets anew and changing the value of S
        //since X keeps changing

        public double[,] s;
        //i removed the property so that it doesn't keep calling gets anew and changing the value of S
        //since X keeps changing

        public double buffer;

        double _function;

        public double Function
        {
            get { return _function; }
            set
            {
                _function = a * Math.Pow(x[0, 0], 2) + b * x[0, 0] + c * x[0, 0] * x[1, 0] + d * x[1, 0]
                                                                            + e * Math.Pow(x[1, 0], 2) + f;
            }
        }

        public bool isMinimum;
        //removed the IsMinimum property that was here


        public void StartAlgorithm()//a lot of changes here
        {
            int i = 1;//changes here
            Console.WriteLine("*********ITERATION {0}***********",i);
            Console.WriteLine();
            GetG();
            GetS();
            GetLambda();
            GetNextPoint1();
            GetGNext();
            Console.WriteLine("The X{2} is, [{0} , {1}]", x[0, 0], x[1, 0], i);
            Console.WriteLine($"The Function F{i} is {Function}");
            Console.WriteLine($"The value of Lambda which minimizes F is {_lambda}");
            Console.WriteLine("The gradient vector G{2} is [{0},{1}]", g[0,0],g[1,0],i);
            GradientCheck();
            if (isMinimum != true)
            {
                Console.WriteLine();
                while (isMinimum != true)
                {
                    i++;
                    Console.WriteLine($"*********ITERATION {i}***********");
                    Console.WriteLine();
                    GetSNext();
                    GetLambda2();
                    GetNextPoint2();
                    g[0, 0] = gNext[0, 0];
                    g[1, 0] = gNext[1, 0];
                    GetGNext();
                    Console.WriteLine("The X{2} is, [{0} , {1}]", x[0, 0], x[1, 0], i);
                    Console.WriteLine($"The Function F{i} is {Function}");
                    Console.WriteLine($"The value of Lambda which minimizes F is {_lambda2}");
                    Console.WriteLine("The gradient vector G{2} is [{0},{1}]", gNext[0, 0], gNext[1, 0], i);
                    Console.WriteLine();
                    Console.WriteLine("*****************************************");
                    GradientCheck();
                }
                Console.WriteLine();
                Console.WriteLine("The optimum point is X[{0} , {1}]", x[0, 0], x[1, 0]);
                Console.WriteLine("*****************************************");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("*****************************************");
                Console.WriteLine();
                Console.WriteLine("The optimum point is X[{0} , {1}]", x[0, 0], x[1, 0]);
                Console.WriteLine("*****************************************");
            }
        }

        public double GetLambda()
        {
            _lambda = -(2 * a * s[0, 0] * x[0,0] + b * s[0, 0] + c * (x[0, 0] * s[1, 0] + x[1,0] * s[0, 0]) + d * s[1, 0] + 2 * e * s[1, 0] * x[1, 0])
                / (2 * a * Math.Pow(s[0, 0], 2) + 2 * c * s[0, 0] * s[1, 0] + 2 * e * Math.Pow(s[1, 0], 2));
            return _lambda;
            //for only quadratic equations of the form specified above
        }

        public double GetLambda2()
        {
            _lambda2 = -(2 * a * sNext[0, 0] * x[0,0] + b * sNext[0, 0] + c * (x[0,0] * sNext[1, 0] + x[1, 0] * sNext[0, 0]) + d * sNext[1, 0] + 2 * e * sNext[1, 0] * x[1, 0])
                / (2 * a * Math.Pow(sNext[0, 0], 2) + 2 * c * sNext[0, 0] * sNext[1, 0] + 2 * e * Math.Pow(sNext[1, 0], 2));
            return _lambda2;
            //for only quadratic equations of the form specified above
        }

        public double[,] GetG()
        {
            //the line of code that was instantiating a new object which was only available within this method,
            //causing my g field to return empty
            g[0, 0] = MathOps.DifferentiateWrtX1(a, b, c, d, e, f, x[0, 0], x[1, 0]);
            g[1, 0] = MathOps.DifferentiateWrtX2(a, b, c, d, e, f, x[0, 0], x[1, 0]); //was differentiating wrt X1 here
            return g;
        }

        public double[,] GetGNext()
        {

            gNext[0, 0] = MathOps.DifferentiateWrtX1(a, b, c, d, e, f, x[0, 0], x[1, 0]);
            gNext[1, 0] = MathOps.DifferentiateWrtX2(a, b, c, d, e, f, x[0, 0], x[1, 0]);
            return gNext;
        }

        public double[,] GetS()
        {
            s = MathOps.MatriXNegativeOne(g);
            return s;
        }

        public double GetBuffer()
        {
            buffer = (MathOps.MultiplyMatrixByMatrix(MathOps.TransposeMatrix(gNext), gNext))                                                                                              
                      / (MathOps.MultiplyMatrixByMatrix(MathOps.TransposeMatrix(g), g));      
            return buffer;
        }

        public double[,] GetSNext()
        {
            sNext = MathOps.AddMatrices(MathOps.MatriXNegativeOne(gNext),MathOps.MultiplyMatrixByScalar(s, GetBuffer())); //the buffer here was returning zero  
            return sNext;                                                                                             //the value of s here is not what it should be
        }

        public double[,] GetNextPoint1()
        {
            var buffer = MathOps.MultiplyMatrixByScalar(s, _lambda);
            x[0, 0] = x[0, 0] + buffer[0, 0];
            x[1, 0] = x[1, 0] + buffer[1, 0];
            return x;
        }
        public double[,] GetNextPoint2()
        {
            var buffer = MathOps.MultiplyMatrixByScalar(sNext, _lambda2);
            x[0, 0] = x[0, 0] + buffer[0, 0];
            x[1, 0] = x[1, 0] + buffer[1, 0];
            return x;
        }

        public bool GradientCheck()
        {
            var abs = Math.Sqrt(Math.Pow(gNext[0, 0], 2) + Math.Pow(gNext[1, 0], 2));//i was using g instead of gNext at first
            if (abs <= tolerance) //i removed the condition function<=0 since its not the correct criteria
            {
                isMinimum = true;//check previous revision for correction made here.
            }
            return isMinimum;
        }
    }
}

