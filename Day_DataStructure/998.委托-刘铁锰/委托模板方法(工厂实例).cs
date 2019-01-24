using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductFactroy productFactroy = new ProductFactroy();
            WarpFactory warpFactory = new WarpFactory();

            Func<Product> func1 = new Func<Product>(productFactroy.MakePizza);
            Func<Product> func2 = new Func<Product>(productFactroy.MakeCar);

            Box box1 =  warpFactory.WarProduct(func1);
            Box box2 = warpFactory.WarProduct(func2);

            Console.WriteLine(box1.Product.Name);
            Console.WriteLine(box2.Product.Name);
        }
    }

    class Product
    {
        public string Name { get; set; }
    }

    class Box
    {
        public Product Product { get; set; }
    }

    class WarpFactory
    {
        public Box WarProduct(Func<Product> getProduct)
        {
            Box box = new Box();
            Product product = getProduct();
            box.Product = product;
            return box;
        }
    }
    
    class ProductFactroy
    {
        public Product MakePizza()
        {
            Product product = new Product();
            product.Name = "Pizza";
            return product;
        }

        public Product MakeCar()
        {
            Product product = new Product();
            product.Name = "Car";
            return product;
        }
    }
}
