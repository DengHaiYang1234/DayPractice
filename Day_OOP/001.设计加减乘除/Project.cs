using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Project
    {
        static void Main()
        {
            string a = "5*5.5";
            char oper;
            double[] nums = Data.GetData(a, out oper);

            OperationController op = new OperationController(oper);
            Console.WriteLine(op.Operation(nums[0], nums[1]));

        }
    }

    class Data
    {
        public static double[] GetData(string data,out char oper)
        {
            char _oper = ' ';
            if (data.IndexOf('+') != -1)
            {
                _oper = '+';
            }
            else if (data.IndexOf('-') != -1)
            {
                _oper = '-';
            }
            else if (data.IndexOf('*') != -1)
            {
                _oper = '*';
            }
            else if (data.IndexOf('/') != -1)
            {
                _oper = '/';
            }
            oper = _oper;
            string[] strs = data.Split(_oper);
            double[] nums = new double[strs.Length];

            for (int i = 0; i < strs.Length; i++)
            {
                nums[i] = double.Parse(strs[i]);
            }

            return nums;
        } 
    }
       
    class OperationController
    {
        private IOperation _operation;

        public OperationController(char oper)
        {
            switch (oper)
            {
                case '+':
                    _operation = new Sum();
                    break;
                case '-':
                    _operation = new Sub();
                    break;
                case '*':
                    _operation = new Mul();
                    break;
                case '/':
                    _operation = new Div();
                    break;
            }
        }

        public double Operation(double x, double y)
        {
            return _operation.Operation(x, y);
        }
    }


    interface IOperation
    {
        double Operation(double x,double y);
    }

    class Sum : IOperation
    {
        public double Operation(double x, double y)
        {
            return x + y;
        }
    }

    class Sub : IOperation
    {
        public double Operation(double x, double y)
        {
            return x - y;
        }
    }

    class Mul : IOperation
    {
        public double Operation(double x, double y)
        {
            return x * y;
        }
    }

    class Div : IOperation
    {
        public double Operation(double x, double y)
        {
            return x / y;
        }
    }


}
