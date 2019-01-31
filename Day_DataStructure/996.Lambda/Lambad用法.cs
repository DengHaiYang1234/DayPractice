using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Lambad用法
    {
        static void Main()
        {

            Func<int, int, int> fun = (x, y) =>
            {
                return x * y;
            };

            Func<IPowerSupply, int> func = ps => ps.GetPower();

            Console.WriteLine(func(new PowerSupply()));

            Action<int, int> ac = (x, y) =>
            {
                Console.WriteLine(x + y);
            };

            ac(10, 10);
        }


    }

    public interface IPowerSupply
    {
        int GetPower();
    }

    public class PowerSupply : IPowerSupply
    {
        public int GetPower()
        {
            return 201;
        }
    }
}
