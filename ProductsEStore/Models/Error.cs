using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsEStore.Models
{
    public class Error : ViewModelBase
    {
        public Exception exception { get; set; }

        public Error()
        {
            exception = new Exception();
        }
        public Error(Exception e)
        {
            exception = e;
        }
    }
}