using System.Collections.Generic;
using ProductsEStore.Models;

namespace ProductsEStore.Core
{
    public class Response
    {
        public IList<Product> ViewProducts { get; set; }
        public int ProductCount { get; set; }

        public Response()
        {

        }
    }
}