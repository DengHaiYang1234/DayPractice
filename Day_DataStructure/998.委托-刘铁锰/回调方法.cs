using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 回调方法
{
    class Program
    {
        static void Main(string[] args)
        {
            WarpFactory warpFactory = new WarpFactory();
            ProductFactory productorFactory = new ProductFactory();
            Logger logger = new Logger();

            Func<Product> func1 = new Func<Product>(productorFactory.CreatPizza);

            Func<Product> func2 = new Func<Product>(productorFactory.CreatCar);

            Box box1 =  warpFactory.warpPoduct(func1, logger.Log);
            Box box2 = warpFactory.warpPoduct(func2, logger.Log);

            Console.WriteLine(box1.product.Name);
            Console.WriteLine(box2.product.Name);
        }
    }

    class Logger
    {
        public void Log(Product product)
        {
            Console.WriteLine("Product:{0},Creat Time:{1},This Price:{2}",product.Name,DateTime.UtcNow,product.Price);
        }
    }

    class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }

    class Box
    {
        public Product product { get; set; }
    }

    class WarpFactory
    {
        public Box warpPoduct(Func<Product> getProduct,Action<Product> callback)
        {
            Box box = new Box();
            box.product = getProduct();
            if (box.product.Price > 110)
            {
                callback(box.product);
            }
            
            return box;
        }
    }

    class ProductFactory
    {
        public Product CreatPizza()
        {
            Product product = new Product();
            product.Name = "Pizza";
            product.Price = 100;
            return product;
        }

        public Product CreatCar()
        {
            Product product = new Product();
            product.Name = "Car";
            product.Price = 200;
            return product;
        }
    }
}
