using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 https://www.cnblogs.com/swordtm/p/6049184.html
 */
namespace Project_2
{
    public delegate void CatShoutEventHandler(object sender,CatShoutEventArgs e);
    class Program
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat("tom");
            Rat rat = new Rat("jerry");
            Rat rat2 = new Rat("jerry2");
            //cat.CatShout = null;
            cat.CatShout += rat.Run;
            cat.CatShout += rat2.Run;
            
            cat.Shout();
        }
    }

    public class CatShoutEventArgs : EventArgs
    {
        public string CatName { get; set; }

        public CatShoutEventArgs(string name)
        {
            this.CatName = name;
        }
    }

    class Cat
    {
        public event CatShoutEventHandler CatShout;

        public string Name;

        public Cat(string name)
        {
            Name = name;
        }

        public void Shout()
        {
            Console.WriteLine("喵喵喵");
            if (CatShout != null)
            {
                CatShoutEventArgs e = new CatShoutEventArgs(Name);
                CatShout(this,e);
            }
        }
    }

    class Rat
    {
        public string name;

        public Rat(string name)
        {
            this.name = name;
        }

        public void Run(object sender,CatShoutEventArgs e)
        {
            Console.WriteLine("{0}来了，快跑啊：{1}", sender, name);
        }
    }
}
