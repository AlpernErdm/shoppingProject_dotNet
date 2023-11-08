using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public IResult Add(Order order )
        {
            _orderDal.Update(order);
            return new SuccessResult();
        }

        public IDataResult<List<Order>> GetAll()
        {
            var result = _orderDal.GetAll();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<Order>>(_orderDal.GetAll());
            }
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll(), Messages.NoDataInList);
        }

        public IDataResult<Order> GetById(int orderId)
        {
            var result = _orderDal.Get(p =>p.OrderId == orderId);
            if (result != null)
            {
                return new SuccessDataResult<Order>(result);
            }
            return new SuccessDataResult<Order>(result, Messages.NoDataOnFilter);

        }

        public IResult Remove(Order order)
        {
            _orderDal.Update(order);
            return new SuccessResult();
        }

        public IResult Update(Order order)
        {
            _orderDal.Update(order);
            return new SuccessResult();
        }
    }


}
