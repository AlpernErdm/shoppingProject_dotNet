using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet("getall")]
        public IActionResult GetBrand()
        {
            var res = _orderService.GetAll();
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var res = _orderService.GetById(id);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }
        [HttpPost("add")]
        public IActionResult Add(Order order )
        {
            var res = _orderService.Add(order);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);

        }
        [HttpPut("update")]
        public IActionResult Update(Order order )
        {
            return Ok(_orderService.Update(order));
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Order order)
        {
            return Ok(_orderService.Remove(order));
        }
    }
}
