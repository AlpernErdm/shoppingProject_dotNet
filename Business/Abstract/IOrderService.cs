using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IOrderService
    {
        IDataResult<List<Order>> GetAll();
        IResult Add(Order order);
        IResult Remove(Order order);
        IResult Update(Order order);
        IDataResult<Order> GetById(int orderId);
    }
}
