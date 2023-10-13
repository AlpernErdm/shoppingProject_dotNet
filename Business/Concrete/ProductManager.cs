using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
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

        public List<Product> GettAll()
        {
            //İşKodları
            return _productDal.GetAll();
           
        }
    }
}
