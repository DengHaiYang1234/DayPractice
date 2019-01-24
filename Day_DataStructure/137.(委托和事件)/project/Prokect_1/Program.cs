using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
1.猫叫了

2.所有老鼠听到叫声,知道是哪只猫来了

3.老鼠们逃跑,边逃边喊:"xx猫来了,快跑啊!我是老鼠xxx"

1.Subject类 (通知者 主题)
//抽象类 里面有一个Observer类集合
把所有对观察者对象的引用保存在一个聚集里,每个主题都可以有多个观察者.抽象主题提供一个接口,可以增加和删除观察着对象

2.Observer类 (观察者)
//抽象类
抽象观察者,为所有的具体观察者定义一个接口,在得到主题的更新时提醒自己

3.ConcreteObserver类
//父类是Observer类
具体观察者,实现抽象观察者角色所需求的更新接口,以便使本身的状态与主题的状态相协调

4.ConcreteSubject类
//父类是Subject
具体主题,将有关状态存入具体观察者对象,在具体主题的内部状态改变时,给所有登记过的观察者发出通知



观察者模式的特点

1.一个主题可以有任意数量依赖他的观察者,一旦主题的状态发生改变,所有观察者都可以得到通知
2.主题发出通知不需要知道具体观察者
3.具体观察者也不需要知道其他观察者的存在

https://www.cnblogs.com/swordtm/p/6049184.html

*/

namespace Prokect_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat("Tom");

            Mouse mouse = new Mouse("Jerry",cat);

            cat.Add(mouse);

            cat.Shout();
        }
    }

    public abstract class Pet 
    {
        public List<IRun> list = new List<IRun>();

        public void Add(IRun i)
        {
            list.Add(i);
        }

        public void Remove(IRun i)
        {
            list.Remove(i);
        }

        public abstract void Shout();
    }

    class Cat : Pet
    {
        public string name;

        public Cat(string name)
        {
            this.name = name;
        }

        public override void Shout()
        {
            Console.WriteLine("喵喵喵！");
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    item.Run();
                }
            }
        }
    }

    class Mouse : IRun
    {
        private string name;

        private Cat cat;


        public Mouse(string name,Cat cat)
        {
            this.name = name;
            this.cat = cat;
        }

        public void Run()
        {
            Console.WriteLine("【{0}】来啦。快跑啊。我是老鼠：{1}",cat.name,name);
        }
    }

    public interface IRun
    {
        void Run();
    }
}
