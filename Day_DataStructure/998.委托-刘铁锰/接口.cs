using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 接口
{
    class Program
    {
        static void Main(string[] args)
        {
            IProductFactroy pizza = new PizzaFactory();
            IProductFactroy toyCar = new ToyCarFactory();

            Logger logger = new Logger();

            WarpFactroy warpFactroy = new WarpFactroy();

            Box box1 =  warpFactroy.WarpProduct(pizza, logger.Log);
            Box box2 = warpFactroy.WarpProduct(toyCar, logger.Log);

            Console.WriteLine(box1.product.Name);
            Console.WriteLine(box2.product.Name);
        }
    }

    class Logger
    {
        public void Log(Product product)
        {
            Console.WriteLine("Product:{0} Craet At {1} ,Prict is:{2}",product.Name,DateTime.UtcNow,product.Price);
        }
    }

    interface IProductFactroy
    {
        Product Make();
    }

    class Product
    {
        public string Name { get; set; }
        public float Price { get; set; }
    }

    class Box
    {
        public Product product { get; set; }
    }

    class WarpFactroy
    {
        public Box WarpProduct(IProductFactroy productFactroy,Action<Product> callback)
        {
            Box box = new Box();
            box.product = productFactroy.Make();
            if (box.product.Price > 50)
            {
                callback(box.product);
            }
            return box;
        }
    }

    class PizzaFactory : IProductFactroy
    {
        public Product Make()
        {
            Product product = new Product();
            product.Name = "Pizza";
            product.Price = 100f;
            return product;
        }
    }

    class ToyCarFactory : IProductFactroy
    {
        public Product Make()
        {
            Product product = new Product();
            product.Name = "ToyCar";
            product.Price = 45f;
            return product;
        }
    }


}
