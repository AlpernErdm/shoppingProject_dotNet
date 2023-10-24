using Core.DataAccess;
using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IOrderDal:IEntityRepository<Order> //sql cümleleri yazacağımız yer(Dal)
    {
    }
}
