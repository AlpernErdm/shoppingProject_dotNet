using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")] //Nasıl istekte bulunacağımızı ifade eder
    [ApiController] //attribute denir
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public List<Product> Get()
        {
            return new List<Product> {
                new Product{ProductID=1,ProductName="Elma"},
                new Product{ProductID=2,ProductName="Armut"}
            };
        }
    }
}
