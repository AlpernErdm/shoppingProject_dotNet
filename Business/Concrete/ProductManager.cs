using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal; //Bir iş sınıfı başka sınıfları newleyemez

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), true, Messages.ProductsListed);
        }

        public IResult Add(Product product)
        {
            //business kodları gelir buraya           
            //Sadece get ile yazdığımız için Set kısmını da constructora vererek resultta döndürebilirz 
            if (product.ProductName.Length<2)
            {
                return new ErrorResult(Messages.ProductNameInValid);
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);          
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>( _productDal.GetAll(p => p.CategoryID == id),true,"Kategoriler listelendi");//verdiğimiz category ıd ye göre filtreleme yapıyo ve bize cevap döndürüyo
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductID == productId),true,"Id");
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>( _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max),true,"Fiyat");//2 fiyat aralığında olan datayı verir
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails(),"Başarılıı");
        }
        

    }
}
