using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
   public class ErrorResult:Result
    {
        public ErrorResult(string message) : base(false, message) //Hem msg hem bool output istersek bunu sadece success durumu için alttaki ctor'u kullanırız
        {

        }
        public ErrorResult() : base(false)
        {

        }
    }
}
