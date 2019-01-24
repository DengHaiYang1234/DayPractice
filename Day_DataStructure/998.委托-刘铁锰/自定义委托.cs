using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public delegate double Calc(double x,double y);

    class Program
    {
        static void Main(string[] args)
        {
            Calcuator calcuator = new Calcuator();
            Calc calc1 = new Calc(calcuator.Add);
            Calc calc2 = new Calc(calcuator.Sub);
            Calc calc3 = new Calc(calcuator.Mul);
            Calc calc4 = new Calc(calcuator.Div);

            double a = 100;
            double b = 200;
            double c = 0;

            c = calc1(a, b);
            Console.WriteLine(c);
            c = calc2(a, b);
            Console.WriteLine(c);
            c = calc3(a, b);
            Console.WriteLine(c);
            c = calc4(a, b);
            Console.WriteLine(c);
        }
    }

    class Calcuator
    {
        public double Add(double x, double y)
        {
            return x + y;
        }

        public double Sub(double x, double y)
        {
            return x - y;
        }

        public double Mul(double x, double y)
        {
            return x * y;
        }

        public double Div(double x, double y)
        {
            return x / y;
        }
    }
}
