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
             ProductTest();

           // CategoryTest();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            //foreach (var product in productManager.GetAllByCategoryId(2)) //CategoryId'sı 2 olanları getirir
            //{
            //    Console.WriteLine(product.ProductName);
            //}
            //Console.WriteLine("**************************");
            //foreach (var item in productManager.GetByUnitPrice(100, 200)) //Fiyatı 100-200 arasındakileri getirir
            //{
            //    Console.WriteLine(item.ProductName);
            //}
            Console.WriteLine("**********************");
            foreach (var product1 in productManager.GetProductDetails()) 
            {
                Console.WriteLine(product1.ProductName+"/"+product1.CategoryName);
            }
        }
    }
}
