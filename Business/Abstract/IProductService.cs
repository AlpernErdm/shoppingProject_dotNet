using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IProductService
    {
        List<Product> GettAll();
        List<Product> GetAllByCategoryId(int id);
        List<Product> GetByUnitPrice(decimal min,decimal max);//verdiğimiz 2 fiyat değeri arasındaki ürünleri getirir
        List<ProductDetailDto> GetProductDetails();


    }
}
