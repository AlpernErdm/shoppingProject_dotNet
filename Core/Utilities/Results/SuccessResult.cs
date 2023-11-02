using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(true, message) //Hem msg hem bool output istersek bunu sadece success durumu için alttaki ctor'u kullanırız
        {

        }
        public SuccessResult() : base(true)
        {

        }
    }
}
