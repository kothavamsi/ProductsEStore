using System.Collections.Generic;
using ProductsEStore.Models;

namespace ProductsEStore.Core
{
    public class Response
    {
        public IList<Product> CurrentPageProducts { get; set; }
        public int ItemsCount { get; set; }

        public Response()
        {

        }
    }
}