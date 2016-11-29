using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductsEStore.Core;

namespace ProductsEStore.Models
{
    public class ProductListViewResult : ViewModelBase
    {
        public bool FoundResult { get; set; }
        public ProductListViewResultHeader Header { get; set; }
        public IList<IProduct> ViewProducts { get; set; }
        public int ProductCount { get; set; }
        public Pager Pager { get; set; }

        // Dependency Injection
        public ProductListViewResult(IRepository repository)
            : base(repository)
        {
            ViewProducts = new List<IProduct>();
            FoundResult = false;
        }
    }

    public class ProductListViewResultHeader
    {
        public string Message { get; set; }
    }
}