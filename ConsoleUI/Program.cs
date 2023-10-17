using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetAllByCategoryId(2)) //CategoryId'sı 2 olanları getirir
            {
                Console.WriteLine(product.ProductName);
            }
            Console.WriteLine("**************************");
            foreach (var item in productManager.GetByUnitPrice(100,200)) //Fiyatı 100-200 arasındakileri getirir
            {
                Console.WriteLine(item.ProductName);
            }
            Console.WriteLine("**********************");
            foreach (var product1 in productManager.GettAll()) //Hepsini getirir
            {
                Console.WriteLine(product1.ProductName);
            }
        }
    }
}
