using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public interface IDataResult<T> : IResult
    {
        //IResultta ki message ve successstate haricinde bir de data döndürmek için data tanımlıyorum
        T Data { get; }
    }
}
