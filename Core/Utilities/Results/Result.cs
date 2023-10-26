using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult //IResult sınıfın somut sınıfı olarak '-'
    {
        public Result(bool success, string message) : this(success) //böyle yaparak returnde tek girişte yapsak tek ctor çift yaparsak çift cons da çalışcak ve hata almıcaz
        //constructor yardımıyla bir bool bir string ifade göndermek istiyoruz
        {
            //Readonly olan getter constuctor  yardımıyla set edilebilir 
            Message = message;
        }
        public Result(bool success) //OVERLOADİNG    //constructor yardımıyla bir bool bir string ifade göndermek istiyoruz
        {
            Success = success; //Burda constuctor kullanarak mesaj yazmadan sadece success durumunu ekrana veren bir ctor yazdık
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
