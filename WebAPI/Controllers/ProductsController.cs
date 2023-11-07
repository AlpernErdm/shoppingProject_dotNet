using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
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
        //Loosely coupled
        IProductService _productService;

        public ProductsController(IProductService productService) //Burası bir IproductService bağımlısı
        {
            //IoC =Inversion of control
            _productService = productService;//field
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var res = _productService.GetAll();
            if (res.Success)
            {
                return Ok(res); //Eğerbaşarı durumu true ise 200 code dön
            }
            return BadRequest(res);//True değilse 400 code  dön 
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var res = _productService.GetById(id);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }
        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var res = _productService.Add(product);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }
    }
}
