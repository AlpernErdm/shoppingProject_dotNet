
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal //Bellekte sanki datamız varmış gibi çalışacağız
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> {
                new Product{CategoryID=1,ProductID=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15 },
                new Product{CategoryID=2,ProductID=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3 },
                new Product{CategoryID=3,ProductID=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2 },
                new Product{CategoryID=4,ProductID=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65 },
                new Product{CategoryID=5,ProductID=2,ProductName="Fare",UnitPrice=85,UnitsInStock=2 }
            }; //Uygulama her çalıştığında listeye yeni eleman ekleyecek Constructor ile
        }
        public void Add(Product product)
        {
            _products.Add(product); //Parametre olarak businessdan gönderilen ürünü veritabanına ekliyoruz  
        }

        public void Delete(Product product)
        {
            //LINQ=Language Integrated Query
            Product productToDelete = _products.SingleOrDefault(p =>p.ProductID==product.ProductID); //linq sorgusu(foreachle aynı mantık)
            _products.Remove(product);
            //benım verdıgım p ile product'ın ıdsı benzer mı bak(döngü)
            //p tek tek dolaşırken verdiğimiz takma isim
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryID == categoryId).ToList();//where ile koşulumu sağlayan bütün ürünleri getirdim
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductID == product.ProductID);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryID = product.CategoryID;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.UnitPrice = product.UnitPrice;
       
        }
    }
}
