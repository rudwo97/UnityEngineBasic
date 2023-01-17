using System;

// Delegate : 대리자
// Methods 에 대한 참조를 나타내는 형식
namespace Delegate
{
    internal class Program
    {
        public delegate int OPHandler(int a, int b);
        public static OPHandler op;
        static void Main(string[] args)
        {
            op = Sum;

            int result = 0;
            result - Sum(1, 2);

            result - op(1, 2);
            
        }

        static int Sum(int a, int b)
        {
            return a + b;
        }
        static int Sub(int a, int b)
        {
            return a - b;
        }
        static int Div(int a, int b)
        {
            return a / b;
        }
        static int Mul(int a, int b)
            return a
    }
}
