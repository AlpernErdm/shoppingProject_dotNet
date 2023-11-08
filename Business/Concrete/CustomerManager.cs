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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.AddedCustomer);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            var result = _customerDal.GetAll();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
            }
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.NoDataInList);
        }

        public IDataResult<Customer> GetById(int customerId)
        {

            var result = _customerDal.Get(p => p.CustomerId == customerId);
            if (result != null)
            {
                return new SuccessDataResult<Customer>(result);
            }
            return new SuccessDataResult<Customer>(result,Messages.NoDataInList);
        }

        public IResult Remove(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult();
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult();
        }
    }
}
