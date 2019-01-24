using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
/*
事件的拥有者
事件
事件的响应者
事件处理器
事件订阅
*/
namespace Porject
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer();

            timer.Interval = 1000;

            Boy boy = new Boy();

            Gril gril = new Gril();

            timer.Elapsed += boy.Action;

            timer.Elapsed += gril.Action;

            timer.Start();
            Console.ReadLine();
        }
    }

    class Boy
    {

        internal void Action(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Jump!");
        }
    }

    class Gril
    {
        internal void Action(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Sing!");
        }
    }
}
