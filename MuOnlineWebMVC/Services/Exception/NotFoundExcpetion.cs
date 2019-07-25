using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuOnlineWebMVC.Services.Exception
{
    public class NotFoundExcpetion : ApplicationException
    {
        public NotFoundExcpetion(string msg) : base(msg)
        {

        }
    }
}
