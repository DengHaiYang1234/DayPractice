using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


//事件成员能够让对象之间的逻辑更加安全且合理。
namespace 自定义事件
{
    //EventHandler  1.这个委托专门用来声明事件的  2.表明这个委托是用来约束事件处理器的 3.这个委托创建的实例是专门用来存储事件处理器的
    public delegate void OrderEventHandler(Custormer custormer, OrderEventArgs e);

    class Program
    {
        static void Main(string[] args)
        {
            Custormer custormer = new Custormer(); //事件的拥有者
            Waiter waiter = new Waiter(); //事件的响应者
            
            //事件
            custormer.Order += waiter.Action; //事件的订阅
            custormer.Action();
            custormer.PayTheBill();
        }
    }

    public class OrderEventArgs:EventArgs
    {
        public string DishName { get; set; }
        public string Size { get; set; }
    }



    public class Custormer
    {
        #region 完整声明事件
        //private OrderEventHandler orderEventHander;//用来存储或者引用事件处理器的

        //public event OrderEventHandler Order //事件声明
        //{
        //    add { this.orderEventHander += value; }

        //    remove { this.orderEventHander -= value; }
        //}

        #endregion
        #region 简化
        public event  EventHandler Order;
        #endregion
        public double Bill { get; set; }

        public void PayTheBill()
        {
            Console.WriteLine("I Will Pay Money:{0}", this.Bill);
        }

        public void WalkIn()
        {
            Console.WriteLine("Walk Into the Restaurant");
        }

        public void SitDown()
        {
            Console.WriteLine("Sit Down.");
        }

        public void Think()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Let Me Think...");
                Thread.Sleep(1000);
            }

            OnOrder("宫保鸡丁","Big");
        }

        protected void OnOrder(string dishName,string size)
        {
            if (this.Order != null)
            {
                OrderEventArgs e = new OrderEventArgs();
                e.DishName = dishName;
                e.Size = size;
                this.Order.Invoke(this, e);
            }
        }

        public void Action()
        {
            Console.ReadLine();
            this.WalkIn();
            this.SitDown();
            this.Think();
        }
    }

    public class Waiter
    {
        internal void Action(object sender, EventArgs e) //事件处理器
        {
            Custormer custormer = sender as Custormer;
            OrderEventArgs orderAgrs = e as OrderEventArgs;
            Console.WriteLine("I Will Serve You Dish - {0}", orderAgrs.DishName);
            double price = 10;
            switch (orderAgrs.Size)
            {
                case "small":
                    price = price*0.5;
                    break;
                case "big":
                    price = price*1.5;
                    break;
                default:
                    break;
            }
            custormer.Bill += price;
        }
    }
}
