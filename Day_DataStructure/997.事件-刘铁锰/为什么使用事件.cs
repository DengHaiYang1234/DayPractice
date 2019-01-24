using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


/*
为什么使用事件：因为事件规定只能出现在 += 或 -=的左边，其他的一概不行。而委托不需要这个规定，随时可以调用

以下使用模拟顾客点餐的情况来说明：
*/
namespace 为什么使用事件
{
    public delegate void OrderEventHandler(Customer customer,OrderEventArgs e);

    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer("Li");
            Waiter waiter = new Waiter();
            customer.Order += waiter.Action;  //这是正常顾客下单

            #region 注：这是使用委托与事件的区别所在
            ////白吃白喝人家给钱
            //Customer BadGuy = new Customer("BadGuy");
            //BadGuy.Order += waiter.Action;

            //OrderEventArgs e = new OrderEventArgs();
            //e.Dish = "满汉全席";
            //e.Size = "Big";
            //BadGuy.Order.Invoke(customer,e); //若使用Event 那么这部分就是错误的  所以更安全

            //OrderEventArgs e1 = new OrderEventArgs();
            //e.Dish = "山珍海味";
            //e.Size = "Big";
            //BadGuy.Order.Invoke(customer, e);

            //BadGuy.PayBill();
            //customer.PayBill();
            #endregion


            customer.Action();
            customer.PayBill();
        }
    }

    public class OrderEventArgs : EventArgs
    {
        public string Dish { get; set; }
        public string Size { get; set; }
    }

    public class Customer//消费者
    {
        public event OrderEventHandler Order; //注意 这里直接声明的一个委托字段

        public double Bill { get; set; }//账单

        public string Name { get; set; }//顾客姓名

        public Customer(string name)
        {
            Name = name;
        }

        public void PayBill()//付款
        {
            Console.WriteLine("{0}:I Will Pay Bill Is :{1}",Name,Bill);
        }

        void WalkIn()
        {
            Console.WriteLine("{0} Walk In Restaurant",Name);
        }

        void SitDown()
        {
            Console.WriteLine("Sit Down.");
        }

        void OrderFood()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Let me Think");
                Thread.Sleep(1000);
            }
            if (Order != null)
            {
                OrderEventArgs e = new OrderEventArgs();
                e.Dish = "宫保鸡丁";
                e.Size = "Big";
                Order(this, e);
            }
        }

        public void Action()
        {
            Console.ReadLine();
            WalkIn();
            SitDown();
            OrderFood();
        }
    }

    class Waiter //服务员
    {
        internal void Action(Customer customer, OrderEventArgs e)
        {
            Console.WriteLine("Hello : {0} ,You Dish - {1}",customer.Name,e.Dish);
            double price = 10;
            switch (e.Size)
            {
                case "Small":
                    price = price*0.5;
                    break;
                case "Big":
                    price = price * 1.5;
                    break;
                default:
                    break;
            }

            customer.Bill += price;
        }
    }
}
