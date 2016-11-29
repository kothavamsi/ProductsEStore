using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductsEStore.Models
{
    public enum ProductType
    {
        Book=1
    }

    public interface IProduct
    {
        ProductType ProductType { get; set; }
        int Id { get; set; }
        string Title { get; set; }
    }
}
