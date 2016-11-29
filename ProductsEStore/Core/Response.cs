using System.Collections.Generic;
using ProductsEStore.Models;

namespace ProductsEStore.Core
{
    public class Response
    {
        public IList<IProduct> ViewProducts { get; set; }
        public int ProductCount { get; set; }

        public Response()
        {

        }
    }
}