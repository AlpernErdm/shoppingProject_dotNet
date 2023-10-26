using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data,bool success,string message):base(data,true,message)//mesaj yazılması istenirse
        {

        }
        public SuccessDataResult(T data,string message):base(data,true,message)//mesaj yazılması istenmezse
        {

        }
        public SuccessDataResult(T data):base(data,true)//default=data
        {
            
        }
        public SuccessDataResult():base(default,true)
        {

        }
    }

}
