using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    //Get:Okumak için
    //Set:Yazmak için
    public interface IResult
    {
        bool Success { get; } //Sadece get kavramı sadece okumaya izin verir(sadece return eder) ,set işlemini constructor ile yapacağız
        string Message { get; }
    }
}
