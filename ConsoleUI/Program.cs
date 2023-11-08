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
            //ProductTest();
            // CategoryTest();
            SuccessState();
        }

        private static void SuccessState()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            var result = productManager.GetProductDetails();

            if (result.Success == true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + "/" + product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
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
        }

    }
}


